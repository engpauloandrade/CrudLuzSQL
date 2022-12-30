/**************************************************************************
*	NOME: [PR_CADASTRO_SEL]
*	DATA: 30/12/2022
*	OBJETIVO: Selecionar itens da tabela Cadastro
**************************************************************************/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PR_CADASTRO_SEL]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[PR_CADASTRO_SEL]
GO

CREATE PROCEDURE [dbo].[PR_CADASTRO_SEL]

AS BEGIN
	SELECT 
		Id,
		Nome,
		Email
	FROM TB_CADASTRO (NOLOCK)
END
GO
