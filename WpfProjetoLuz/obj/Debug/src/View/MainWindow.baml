   M S B A M L   `   `   `  ????H  DWpfProjetoLuz, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfProjetoLuzWpfProjetoLuz  5   	       WpfProjetoLuz.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:WpfProjetoLuz     5   	     ? Title$  Cadastro de usuário??5   	    ? WindowStyle$ SingleBorderWindow=?6&   
?????d?$	??450??6c   $	??800??6p   .??5
      ? $	??427??6   .+?5   
   &   System.Windows.Controls.DataGrid  -   5        $??dtgCadastro??5   ?      AutoGenerateColumns .     CanUserResizeRows .  $??
362,0,0,74q?6?   ??6/   ?? *listaUsuarios+ ?? SelectedItem 6o   ?? *UsuarioSelecionado+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        	txtId??,  &System.Windows.Controls.DataGridColumn   Header$ Id??5   P      Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6\      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 64   ?? 
 ?? Path$
 Id?6h     5      -   5        txtNome??$
 Nome??5   T   $	 120 6b    . 	 66   ?? $

 Name?6n     5      -   5        txtEmail??$ Email??5   V   $	 110 6e    . 	 67   ?? $
 Email?6q   5      ?? 5   
   $??Inserir??6   $
??Left=?6#   $??0q?6>   $??362,377,0,0q?6n   $	??Top=?6?   $??27??6?   $??62??6?    ? IsSharedSizeScope . ???	#FF47C74F??6R   ?? *	Inserir+6?   ?? 5   
   $??Remover??6   $
??Left=?6#   $??0q?6>   $??443,377,0,0q?6n   $	??Top=?6?   $??27??6?   $??64??6?   ???	#FFBF4C4C??6R   ?? *	Remover+6?   ?? 5   
   $??	Atualizar??6   $
??Left=?6%   $??0q?6@   $??719,377,0,0q?6r   $	??Top=?6?   $??27??6?   $??62??6?    . ???	#FFBAC747??6T   ?? *	Atualizar+6?   ?? 5   
   -   5        $
??Sair??5      $
??Left=?6    $??0q?6;   $??
28,377,0,0q?6O   $	??Top=?6c   $??27??6{   $??43??6?   ???	#FF940A0A???	#FFEADCDC6?   ?? 5   
   -   5        $??Exibir data e hora??5      $
??Left=?6/   $??106,377,0,0q?6J   $	??Top=?6_   $??27??6w   $	??112??6?   ???	#FF369496???	#FFF3E9E96?   5      5      