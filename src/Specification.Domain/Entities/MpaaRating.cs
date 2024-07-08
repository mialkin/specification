namespace Specification.Domain.Entities;

/// <summary>
/// Motion Picture Association film rating system.
/// </summary>
public enum MpaaRating
{
    /// <summary>
    /// General Audiences.
    /// </summary>
    G = 1,

    /// <summary>
    /// Parental Guidance Suggested.
    /// </summary>
    Pg = 2,

    /// <summary>
    /// Parents Strongly Cautioned.
    /// </summary>
    Pg13 = 3,

    /// <summary>
    /// Restricted.
    /// Under 17 requires accompanying parent or adult guardian. Contains some adult material.
    /// Parents are urged to learn more about the film before taking their young children with them.
    /// </summary>
    R = 4
}
