   M S B A M L   `   `   `  ����J  FHotelManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:HotelManagementHotelManagement  5   	   "    HotelManagement.ReportWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:HotelManagement     5   	     � Title$  ReportWindow��5   	   $	��450��6   $	��800��6+   .��5	      � .+�5
   
   �� $
��Left=�6   $��	30,42,0,0q�6/   $
��Wrap=�6B   $��Report content: ��6V   $	��Top=�6n   �� 5   
   $
��Left=�6   $��	30,21,0,0q�6/   $
��Wrap=�6B   $��Report content: ��6V   $	��Top=�6n   �� 5   
   -   5         ��Name$ 
txtContent��5      $
��Left=�6&   $��
120,42,0,0q�6A    �� TextWrapping$
 Wrap=�6U   $�� ��6i   $	��Top=�6q   $	��648��6�   $��38��6�   �� 5   
   -   5        $ txtId��5      $
��Left=�6!   $��
120,16,0,0q�6<   $
 Wrap=�6P   $�� ��6d   $	��Top=�6l   $��94��6�   $��21��6�   ${�False��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DgData��5      $��120,85,26,28q�6#      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ No��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *id+  5      $ Report��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 65    6?   �� *	Content+5      �� 5   
   -   5        $	��Add��5      $
��Left=�6   $��725,411,0,0q�6:   $	��Top=�6O   $��49��6g   6r   �� 5   
   -   5        $��Delete��5      $
��Left=�6"   $��616,411,0,0q�6=   $	��Top=�6R   6j   �� 5   
   -   5        $��Update��5      $
��Left=�6"   $��20��6=   $��667,411,0,0q�6I   $	��Top=�6^   $��45��6v   6�   5      5      