flowchart LR
    %% Atores externos
    R[Recepcionista]
    E[Enfermeiro]
    M[Médico]

    %% Processos do Sistema
    P1[(Cadastro de Paciente)]
    P2[(Geração de Número de Atendimento)]
    P3[(Gerenciamento da Fila de Espera)]
    P4[(Registro de Triagem)]
    P5[(Atendimento Médico)]

    %% Banco de Dados
    DB[(Base de Dados SQL Server)]

    %% Fluxos de Dados
    R -->|Dados do Paciente| P1
    P1 -->|Novo Paciente| DB

    R -->|Solicita Atendimento| P2
    P2 -->|Número de Atendimento| P3
    P2 --> DB

    R -->|Consulta Fila| P3
    P3 -->|Fila Atualizada| R

    E -->|Dados de Triagem| P4
    P4 -->|Triagem Registrada| DB
    P4 -->|Encaminhamento| P5

    M -->|Solicita Próximo| P5
    P5 -->|Paciente Chamado| M
    P5 --> DB
