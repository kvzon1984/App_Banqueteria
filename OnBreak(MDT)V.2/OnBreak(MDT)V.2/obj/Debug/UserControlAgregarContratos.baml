   M S B A M L   `   `   `  ����J  FOnBreak(MDT)V.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:OnBreak_MDT_V._2OnBreak_MDT_V._2  5      2    ,OnBreak_MDT_V._2.UserControlAgregarContratos   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:OnBreak_MDT_V._2     5      X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  6;   .��5      � 
�������.+�5   
   �� $	��Rut��6   $
��Left=�6   $��	50,41,0,0q�69   $	��Top=�6L     J� RenderTransformOrigin$  0.304,-0.768&�6d   �� 5   
   $��Numero Contrato��6   $
��Left=�6*   $��	50,81,0,0q�6E   $	��Top=�6X   $  0.562,-0.08&�6p   �� 5   
   $��Fecha Creacion��6   $
��Left=�6)   $��
50,121,0,0q�6D   $	��Top=�6X   $  0.433,-1.359&�6p   �� 5   
   $��Fecha Termino��6   $
��Left=�6(   $��
50,161,0,0q�6C   $	��Top=�6W   �� 5   
   $��Modalidad de Servicio��6   $
��Left=�60   $��
50,246,0,0q�6K   $	��Top=�6_   �� 5   
   $��Tipo Evento��6   $
��Left=�6&   $��
50,205,0,0q�6A   $	��Top=�6U   $  -0.309,-4.368&�6m   �� 5   
   $��
Asistentes��6   $
��Left=�6%   $��
50,288,0,0q�6@   $	��Top=�6T   $  -0.266,-4.853&�6l   �� 5   
   $��Personal Adicional��6   $
��Left=�6-   $��
50,327,0,0q�6H   $	��Top=�6\   $  0.734,-3.34&�6t   �� 5   
   -   5         ��Name$ txtRut��5      $
��Left=�6"   $��23��6=   $��
185,41,0,0q�6I    �� TextWrapping$
 Wrap=�6]   $�� ��6q   $	��Top=�6y   $	��135��6�   �� 5   
   -   5        $ txtNumeroContrato��5      $
��Left=�6-   $��23��6H   $��
185,81,0,0q�6T   $
 Wrap=�6h   $�� ��6|   $	��Top=�6�   $	��135��6�   �� 5   
   -   5         ��Name$ cboModalidad��5      $
��Left=�6)   $��185,242,0,0q�6D   $	��Top=�6Y   $	��135��6q   �� 5   
   -   5        $ cboTipoEvento��5      $
��Left=�6*   $��185,201,0,0q�6E   $	��Top=�6Z   $	��135��6r   �� 5   
   -   5         ��Name$ 	btnBuscar��5      $��Buscar��6$   $
��Left=�65   $��
358,32,0,0q�6P   $	��Top=�6d   $	��100��6|   $  0.453,-0.031&�6�   �� 5   
   -   5        $ 	btnListar��5      $��Listar��6$   $
��Left=�65   $��
358,81,0,0q�6P   $	��Top=�6d   $	��100��6|   6�   �� 5   
   -   5        $ 	btnEditar��5      $��Editar��6$   $
��Left=�65   $��358,139,0,0q�6P   $	��Top=�6e   $	��100��6}   6�   �� 5   
   -   5        $ 
btnGuardar��5      $��Guardar��6%   $
��Left=�67   $��632,472,0,-54q�6R   $	��Top=�6i   $	��143��6�   6�   �� 5   
   $��Hora de Inicio��6   $
��Left=�6)   $��389,238,0,0q�6D   $	��Top=�6Y   �� 5   
   $��Hora de Termino��6   $
��Left=�6*   $��389,281,0,0q�6E   $	��Top=�6Z   $  1.111,0.417&�6r   (  "System.Windows.Controls.DatePicker  5    
   -	   5          Name$ dtpFechaInicio��5       $
��Left=�6-   $��185,120,0,0q�6H   $	��Top=�6]   $	��135��6u     5!   
   -
   5        $ dtpFechaTermino��5!      $
��Left=�6.   $��185,160,0,0q�6I   $	��Top=�6^   $	��135��6v   �� 5"   
   $
��Left=�6   $	��168��6/   $��
555,25,0,0q�6<   $	��Top=�6P   $	��175��6h   ��5#      �� 5$      -   5        imgContrato�� �� ImageSource$, &/Images/dark_logo_white_background.jpg��5$   2   5&      �� 5)   
   $��Total $��6   $
��Left=�6"   $��389,321,0,0q�6=   $	��Top=�6R   $  0.061,0.458&�6j   �� 5*   
   -   5         ��Name$ txbTotal��5*      $
��Left=�6&   $��23��6A   $��432,321,0,0q�6M   $
��Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��222��6�   $��14(�6�   $��Arial Black)�6�   �� 5+   
   -   5        $ txtAsistentes��5+      $
��Left=�6)   $��23��6D   $��185,289,0,0q�6P   $
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��135��6�   �� 5,   
   $��Observaciones��6   $
��Left=�6(   $��389,399,0,0q�6C   $	��Top=�6X   �� 5-   
   -   5        $ txtObservaciones��5-      $
��Left=�6,   $��57��6G   $��500,366,0,0q�6S   $
 Wrap=�6h   $	��Top=�6|   $	��196��6�   �� 5.   
   -   5        $ txtPersonalAdicional��5.      $
��Left=�60   $��23��6K   $��185,328,0,0q�6W   $
 Wrap=�6l   $�� ��6�   $	��Top=�6�   $	��135��6�   6�   &   Xceed.Wpf.Toolkit.DateTimePicker  5/   
   -   5          Name$ dtpHoraInicio��5/      $��25��65   $
��Left=�6C   $��500,238,0,0q�6`   $	��Top=�6x   $	��129��6�   &   Xceed.Wpf.Toolkit.DateTimeUpDown	   Format$	 	ShortTime=�6�     50   
   -   5        $ dtpHoraTermino��50      $��25��66   $
��Left=�6D   $��500,280,0,0q�6a   $	��Top=�6y   $	��129��6�   $	 	ShortTime=�6�   	� 51   
   -   5        
 	�Name$
 rbtRealizado��51      $��	Realizado��6,   $
��Left=�6@   $��145,402,0,0q�6[   $	��Top=�6p   �� 52   
   $)��#Marque si el contrato esta cumplido��6   $
��Left=�6>   $��
72,378,0,0q�6Y   $	��Top=�6m   �� 53   
   -   5        $ btnActualizar��53      $��
Actualizar��6(   $
��Left=�6=   $��358,184,0,0q�6X   $	��Top=�6m   $	��100��6�   6�   55      56      