classDiagram
    class Paciente {
        int Id
        string Nome
        string Telefone
        string Sexo
        string Email
        +Cadastrar()
        +Editar()
        +Excluir()
    }

    class Atendimento {
        int Id
        int NumeroSequencial
        int PacienteId
        Date DataHoraChegada
        string Status
        +GerarNumeroSequencial()
        +ChamarPaciente()
    }

    class Triagem {
        int Id
        int AtendimentoId
        string Sintomas
        string PressaoArterial
        decimal Peso
        decimal Altura
        int EspecialidadeId
        +RegistrarTriagem()
    }

    class Especialidade {
        int Id
        string Nome
    }

    Paciente "1" --> "0..*" Atendimento
    Atendimento "1" --> "0..1" Triagem
    Triagem "1" --> "1" Especialidade
