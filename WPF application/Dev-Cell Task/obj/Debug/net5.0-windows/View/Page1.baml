   M S B A M L   `   `   `  ����H  DDev-Cell Task, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Dev_Cell_Task.ViewModelDev_Cell_Task.ViewModel  5   	       Dev_Cell_Task.View.Page1   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Dev_Cell_Task.ViewModel     5   	     � Title$  Page1��5   	   $	��500��6   $	��800��6$    � DataContext 5      /  )Dev_Cell_Task.ViewModel.PageDataViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6    $��
10,10,0,50q�60   $
��Left=�5      $
��Left=�6.   $	��350��6P   ��5   D   �� *	page1Data+ �� View 5      �� 5      .P�5      ��    ListViewStyle �� HeaderContainerStyle# [  6%   $��Email��5   %    �� Width$	 200��64    �� DisplayMemberBinding 6@   �� *email+�� 5      # [  6%   $��
First Name��5    %   $	 150��69    6E   �� *
first_name+�� 5!      # [  6%   $��	Last Name��5"   %   $	 150��68    6D   �� *	last_name+�� 5#      # [  6%   $��Avatar��5$   %   $
 Auto��65    �� CellTemplate 5%      �� 5&      .R�5'      �� ��6$   �� *avatar+5(      5+      5,      5.      �� 50   
   -   5        $��Next page >��50      $
��Auto��6'   $��30��64   $��0��6@   $��1��6P   $��10q�51      $��Bottom=�6   $
��Left=�68   
�������52   $   �� 53   
   -   5        $��Main_Screen_btn��55   $   $��Main Screen��53      $
��Auto��6'   $��30��64   $��0��6@   $��1��6P   $��10q�54      $��Bottom=�6   $��Right=�68   
�������55   ;   56      58      