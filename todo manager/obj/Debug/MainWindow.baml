   M S B A M L   `   `   `  ����  todo manager    todo_manager.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � Title$ To Do Manager��5   	   $	��350��6   $	��525��6,    � Icon$" Microsoft_To-Do_icon.svg.ico��68   .��5      �  � ColumnDefinitions 5   
   �� 5	      $	��300 �6   6-   �� 5
      $	��300 �6   6-   .+�5   
   �� -   5        $��	Container��5      $	��300��6#   $��0��6/   6[   �� 5   
   $��1��6   $��5q�6%   $	��200��60   $
��Left=�6<   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��5q�62   .+�5      �� $��50��6   Title:6/   �� 5      -   5        $��title��5      $	��140��6'   65   5      �� 5      $ 
Horizontal=�6   $��5q�62   .+�5      �� $��50��6   Descr:60   �� 5      -   5        $��descr��5      $	��140��6+   $	��100��67    � 	Resources 5       �� 
TargetType �� Property	 �� Value��%�   'J�       �� 5      " J�6    .�5      ��  �@��Margin$	 0q�67   �� 5       �@��
LineHeight$	 16��6;   5      5      5      5      �� 5      -   5        
 � Cursor$

 Hand��5   !   .��6/   Add64   5      �� 5    
   $ 
Horizontal=�6   60   5!      5"      