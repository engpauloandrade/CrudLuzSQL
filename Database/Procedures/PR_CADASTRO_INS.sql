/**************************************************************************
*	NOME: [PR_CADASTRO_INS]
*	DATA: 30/12/2022
*	OBJETIVO: Inserir itens da tabela CADASTRO
**************************************************************************/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PR_CADASTRO_INS]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[PR_CADASTRO_INS]
GO

CREATE PROCEDURE [dbo].[PR_CADASTRO_INS]
(
	@Nome NVARCHAR(50),
	@Email NVARCHAR(50),
	@Password INT
)

AS BEGIN
	INSERT INTO TB_CADASTRO (Nome, Email, Password) 
		   VALUES (@Nome, @Email, @Password)
END
GO