%%{ init: { "theme": "default" } }%%
graph TD
    R["Recepcionista"] --> UC1["Cadastrar Paciente"]
    R --> UC2["Gerar Número de Atendimento"]
    R --> UC3["Visualizar Fila de Espera"]
    E["Enfermeiro"] --> UC4["Registrar Triagem"]
    E --> UC5["Direcionar para Especialidade"]
    M["Médico"] --> UC6["Chamar Paciente"]

    subgraph Sistema
        UC1
        UC2
        UC3
        UC4
        UC5
        UC6
    end
