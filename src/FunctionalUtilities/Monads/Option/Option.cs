/*
    This file includes code from Optional 
    (https://github.com/zoran-horvat/optional) licensed under the MIT License.
    Copyright (c) 2016 Zoran Horvat
   
    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE.
*/

namespace FunctionalUtilities.Monads.Option;

public struct Option<T> : IEquatable<Option<T>> where T : class
{
    private T? _content;

    public static Option<T> Some(T obj) => new() { _content = obj };
    public static Option<T> None() => new();

    public Option<TResult> Map<TResult>(Func<T, TResult> map) where TResult : class => new() 
    { 
        _content = _content is not null 
            ? map(_content) 
            : null 
    };

    public Option<TResult> MapOptional<TResult>(Func<T, Option<TResult>> map) where TResult : class => 
        _content is not null 
            ? map(_content) 
            : Option<TResult>.None();

    public T Reduce(T orElse) => _content ?? orElse;
    public T Reduce(Func<T> orElse) => _content ?? orElse();

    public Option<T> Where(Func<T, bool> predicate) => _content is not null && predicate(_content) 
        ? this 
        : None();

    public Option<T> WhereNot(Func<T, bool> predicate) => _content is not null && !predicate(_content) 
        ? this 
        : None();

    public override int GetHashCode() => _content?.GetHashCode() ?? 0;
    public override bool Equals(object? obj) => obj is Option<T> option && Equals(option);

    public bool Equals(Option<T> other) => _content is null 
            ? other._content is null
            : _content.Equals(other._content);

    public static bool operator ==(Option<T>? a, Option<T>? b) => a is null 
        ? b is null 
        : a.Equals(b);
    
    public static bool operator !=(Option<T>? a, Option<T>? b) => !(a == b);

    public static implicit operator Option<T>(T? obj) => obj is not null
        ? Some(obj)
        : None();
}