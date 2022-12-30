/**************************************************************************
*	NOME: [PR_CADASTRO_UPD]
*	DATA: 30/12/2022
*	OBJETIVO: Atualizar itens da tabela Cadastro
**************************************************************************/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PR_CADASTRO_UPD]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[PR_CADASTRO_UPD]
GO

CREATE PROCEDURE [dbo].[PR_CADASTRO_UPD]
(
	@Id INT,
	@Nome NVARCHAR (50),
	@Email NVARCHAR (50)
)

AS BEGIN
	UPDATE TB_CADASTRO
		SET Nome = @Nome, 
			Email = @Email
		WHERE id = @Id
END
GO