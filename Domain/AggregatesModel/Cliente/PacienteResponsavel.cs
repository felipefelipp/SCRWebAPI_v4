﻿namespace Domain.AggregatesModel.Cliente;

public class PacienteResponsavel
{
    public int PacienteResponsavelId { get; set; }
    public int PacienteId { get; set; }
    public int ResponsavelId { get; set; }
}
