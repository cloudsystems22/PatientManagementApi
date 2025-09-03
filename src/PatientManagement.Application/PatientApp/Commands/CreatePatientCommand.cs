namespace PatientManagement.Application.PatientApp.Commands;

public class CreatePatientCommand
{
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Sex { get; set; } = string.Empty;
    public string EmailAdress { get; set; } = string.Empty;
}