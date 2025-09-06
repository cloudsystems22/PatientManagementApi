namespace PatientManagement.Domain.Entities;

public class Triage
{
    public string Id { get; set; }
    public string CareId { get; set; }
    public string Symptoms { get; set; } = string.Empty;
    public string BloodPressure { get; set; } = string.Empty;
    public decimal Weight { get; set; }
    public decimal Height { get; set; }
    public string SpecialtyId { get; set; }

    /// <summary>
    /// Calculates the Body Mass Index (BMI).
    /// Formula: weight (kg) / (height (m) * height (m)).
    /// Returns 0 if height or weight is zero to avoid division by zero errors.
    /// </summary>
    public decimal IMC => (Height > 0 && Weight > 0) ? Weight / (Height * Height) : 0;

    /// <summary>
    /// Provides a classification for the Body Mass Index (BMI).
    /// </summary>
    public string IMCClassification
    {
        get
        {
            var imc = this.IMC;
            if (imc < 18.5m) return "Abaixo do peso";
            if (imc < 25.0m) return "Peso normal";
            if (imc < 30.0m) return "Sobrepeso";
            if (imc < 35.0m) return "Obesidade Grau I";
            if (imc < 40.0m) return "Obesidade Grau II";
            if (imc >= 40.0m) return "Obesidade Grau III";
            return "Não calculado";
        }
    }

    public Care Care { get; set; } = null!;
    public Speciality Specialty { get; set; } = null!;
}