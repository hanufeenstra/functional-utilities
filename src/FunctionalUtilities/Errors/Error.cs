using FunctionalUtilities.Rules;

namespace FunctionalUtilities.Errors;

public sealed record Error(
    string Title,
    string Detail,
    IDictionary<string, string[]> Errors)

{
    public static readonly Error None = new(string.Empty, string.Empty, new Dictionary<string, string[]>());
    
    public static Error FromBusinessRule(AbstractRule rule) => 
        new(rule.Title, rule.Details, new Dictionary<string, string[]>());
    
    public static Error FromBusinessRule(AbstractAsyncRule rule) => 
        new(rule.Title, rule.Details, new Dictionary<string, string[]>());
    
    public static Error FromValidationResult(IDictionary<string, string[]> errors) =>
        new("Validation Error", "One or more fields failed the validation check", errors);
}