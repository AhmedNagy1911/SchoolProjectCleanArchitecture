using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Infrasturcture.Options;

public class FrontendOptions
{
    public const string SectionName = "Frontend";

    [Required, Url]
    public string BaseUrl { get; init; } = string.Empty;
}