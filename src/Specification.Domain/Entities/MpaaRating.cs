namespace Specification.Domain.Entities;

/// <summary>
/// Система рейтингов Американской киноассоциации, Motion Picture Association film rating system.
/// </summary>
public enum MpaaRating
{
    /// <summary>
    /// General Audiences.
    /// Нет возрастных ограничений.
    /// </summary>
    G = 1,

    /// <summary>
    /// Parental Guidance Suggested.
    /// Рекомендуется присутствие родителей.
    /// </summary>
    Pg = 2,

    /// <summary>
    /// Parents Strongly Cautioned.
    /// Детям до 13 лет просмотр не желателен.
    /// </summary>
    Pg13 = 3,

    /// <summary>
    /// Restricted.
    /// Лицам до 17 лет обязательно присутствие взрослого.
    /// </summary>
    R = 4
}
