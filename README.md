# WPFCrudLuz

## **Aplicação WPF**

Projeto de um CRUD em aplicação .NET, utilizando WPF e SQLServer.

Aplicação desenvolvida com Padrão Arquitetural MVVM. 

Para o banco de dados, você pode criar uma tabela teste utlizando:
```
CREATE TABLE TB_CADASTRO (
[Id] INT IDENTITY (1,1) NOT NULL,
[Nome] NVARCHAR (50) NULL,
[Email] NVARCHAR (50) NULL,
[Password] INT
CONSTRAINT [PK_CADASTRO] PRIMARY KEY CLUSTERED ([Id] ASC)
);
```
# **Pontos da atividade:** 

- Aplorar os conceitos de DataContext e Binding.

- Explorar os conceitos de RelayCommand.



**A linguagem utilizada é C#**
