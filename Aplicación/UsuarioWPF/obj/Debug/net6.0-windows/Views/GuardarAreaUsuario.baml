   M S B A M L   `   `   `  ����E  AUsuarioWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:UsuarioWPF.ViewsUsuarioWPF.Views  5   	   )    #UsuarioWPF.Views.GuardarAreaUsuario   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:UsuarioWPF.Views     5   	     � Title$  GuardarAreaUsuario��5   	   $	��450��6$   $	��500��61   .��5	      � $	��600��6   $	��450��6   .+�5
   
   �� $��Nombre��6   $��25q�6!   $	��Top=�6-   $
��left=�6E   �� 5   
   ${�False��6   $��30��6$      errorTemplate =� ErrorTemplate# [  6�   $	��200��6�   $��25,50q�6�   $	��Top=�6�   $
��left=�6  $��1q�6  ���#E0E0E0��60   �� *Nombre+ �� ValidatesOnExceptions$
 True�� �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�63  �� 5   
   $��Apellido��6   $��25,90q�6#   $	��Top=�62   $
��left=�6J   �� 5   
   ${�False��6   $��30��6$   $	��200��60   $��25,115q�6�   $	��Top=�6�   $
��left=�6�   $��1q�6�   ���#E0E0E0��6<   �� *
Apellido+$ PropertyChanged=�$ TwoWay=�6�   �� 5   
   $��Cédula��6   $��25,150q�6!   $	��Top=�61   $
��left=�6I   �� 5   
   ${�False��6   $��30��6$   $	��200��6z   $��25,180q�6�   $	��Top=�6�   $
��left=�6�   $��1q�6�   ���#E0E0E0��60   �� *Cedula+$ PropertyChanged=�$ TwoWay=�6�   �� 5   
   $��Áreas��6   $��25,210q�6    �� 5   
   $��20��5   =   $	��200��6I   $��25,235q�6U   $	��Top=�6e   $
��left=�6}   ��5      �� *Areas+ �� SelectedItem 5      �� *AreaSeleccionada+��5      �� 5      .R�5      �� �� 5      �6   �� *Nombre+5      5      5      �� 5   
   $��30��6   $��Guardar��6�   $��85��6�   $��Center=�6�   $��5q�6�   $��25,285q�6�   $��Center=�6�   $��Right=�6	  $��1q�6%  ���#E0E0E0 J� RenderTransformOrigin$ 0.627,-6.352&�6O  ��6   �� *GuardarUsuarioCommand+{�6G   �� *)'GuardarUsuarioCommand.CanGuardarUsuario+$ TwoWay=�6O  �� 5   
   $	��200��6   
���  ��$��Center=�6I   $��5q�6k   $��25,285q�6w   $��Center=�6�   $
��Left=�6�   ��6-   �� *	Mensaje+6�   5       5!      