using System;

namespace DiceRolling.Attributes;

/// <summary>
/// Interface que define os valores de um atributo.
/// </summary>
public interface IAttributeValues {
    /// <summary>
    /// Valor mínimo do atributo.
    /// </summary>
    int MinValue { get; }

    /// <summary>
    /// Valor máximo do atributo.
    /// </summary>
    int MaxValue { get; }

    /// <summary>
    /// Valida se os valores mínimo e máximo são consistentes.
    /// </summary>
    /// <returns>true se MinValue é menor que MaxValue</returns>
    void ValidateValues() {
        if (MinValue >= MaxValue) {
            throw new ArgumentException("MinValue must be less than MaxValue");
        }
    }
}