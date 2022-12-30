/**************************************************************************
*	NOME: [PR_CADASTRO_DEL]
*	DATA: 30/12/2022
*	OBJETIVO: Deletar itens da tabela Cadastro
**************************************************************************/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PR_CADASTRO_DEL]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[PR_CADASTRO_DEL]
GO

CREATE PROCEDURE [dbo].[PR_CADASTRO_DEL]
(
	@Id INT
)

AS BEGIN
	DELETE FROM TB_CADASTRO
		WHERE Id = @Id
END
GO
