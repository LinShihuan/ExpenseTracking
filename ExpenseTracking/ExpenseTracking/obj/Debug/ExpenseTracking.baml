   M S B A M L   `   `   `  ����J  FExpenseTracking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ExpenseTrackingExpenseTracking  5   	        ExpenseTracking.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   R NOxyPlot.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0 oxyhttp://oxyplot.org/wpf  5   	   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   )localclr-namespace:ExpenseTracking  5   	   -   5          �Name$  expenseWindow��5   	    � Title$ Expense Tracking System��5
   	   $	��600��6)   $
��1000��69    � 	Resources 5      $   ExpenseTracking.MonthConverter   MonthConverter��%   &	          5   
   6   5      .��5      �  � RowDefinitions 5   
   �� 5      $��25 �6   �� 5      $��50 �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ]� $��0��6   .+�5      o� $	��Top=�6   .@�5      m� -   5         m�Name$ menuFile��5      $
��File��6-   .@�5      m� -   5        $ menuOpen��5      $
��Open��61   .@�5      m� -   5        $ menuOpenSerial��5   #   $��OpenSerializerXML��6;   m� 5      -   5        $ menuOpenXML��5   #   $��OpenXML��68   m� 5      -   5        $ menuOpenText��5   #   $��OpenText��69   5      m� 5      -   5        $ menuSave��5      $
��Save��61   .@�5      m� -   5        $ menuSaveSerial��5   #   $��SaveSerializerXML��6;   m� 5      -	   5        $ menuSaveXML��5   #   $��SaveXML��68   m� 5       -
   5        $ menuSaveText��5    #   $��SaveText��69   5!      m� 5"      -   5        $ menuExit��5"      $
��Exit��61   6A   5#      5$      5%      �� 5&   
   $��1��6    �� Orientation$ 
Horizontal=�6"   .+�5'      �� $��Logged In As:��6   $��20, 10, 10, 10q�6-   $��15(�6E   �� 5(      $	��200��6=   {�.  $��15(�6[   $��0, 10, 10 , 10q�6i   ��6   �� *
UserName+ �� Mode$ OneWay=�6i   5)      �� 5*   
   $��2��6   $��Stretch=�6$   $��Center=�6B    �� ShowsPreview . $��3��5+      $��20, 0, 20, 0q�6"   � 5,   
   $��3��6    5-      �� 5.      $��5 �6    �� 5/      $��* �6     � ColumnDefinitions 51      �� 52      $��1* �6#   �� 53      $��3* �6#   �� 54      $��1* �6#   .+�56      �� $��0��6   $��0��6(   $��3��68   9� 59      $��1��6   $��0��6)   $��Expense��6:   $
��Auto��6K   
����� �$��10, 0, 0, 0q�6k   $	��Top=�6�   .��5:      �� $��
3, 3, 3, 3q�6   
�����_�$
��Auto��6R   ._�5;      � 
�������$��
0, 0, 0, 0q�6.    5<      �� 5=      $��35 �6,   �� 5>      $��35 �6,   �� 5?      $��35 �6,   �� 5@      $	��100 �6,    5B      �� 5C      $��1* �6/   �� 5D      $��2* �6/   .+�5F      �� $	��Tag��6$   $��0��6/   $��0��6<   $��15(�6L   $��10, 5, 5, 5q�6Z   �� 5G      -   5        	 ��Name$	 textTag��5G   "   $��0��63   $��1��6@   $��10, 5, 5, 5q�6P   ��6e   �� *TagAdd+�� 5H      $��Amount��6$   $��1��62   $��0��6?   $��15(�6O   $��10, 5, 5, 5q�6]   �� 5I      -   5        $	 
textAmount��5I   "   $��1��6R   $��1��6_   $��10, 5, 5, 5q�6o   ��67   �� *	AmountAdd+6o   �� 5J      $
��Date��6$   $��2��60   $��0��6=   $��15(�6M   $��10, 5, 5, 5q�6[   (  "System.Windows.Controls.DatePicker  5K      -   5        
  Name$
 datePickter��5K   %   $��2��6:   $��1��6G   $��10, 5, 5, 5q�6W      SelectedDateFormat$ Short=�6l   �� 5L      -   5         ��Name$ buttonAddExpense��5L   !   $��Add Expense��6;   $��3��6Q   $��0��6^   $��2��6n   $��35��6�   $	��100��6�   5M   !   5N      5O      5P      �� 5R      -   5        $��1��5R      $��1��6&   $��5, 5, 5, 10q�66   
����� �.@�5S      �� $��View Expense��6   .��5T      �  5U      �� 5V      $
��1.5* �6,   �� 5W      $��1* �6,   .+�5Y      &   System.Windows.Controls.DataGrid  -   5          Name$ datagridExpense��5Y   #   $��0��6<      AutoGenerateColumns .     CanUserAddRows .     CanUserSortColumns .     
IsReadOnly .    SelectionMode$ Single=�5Z   P      SelectionUnit$ FullRow=�6g   $
��Left=�5\   #   ��.  �� AlternationCount$ 2��6c      AlternatingRowBackground
 �����"   VerticalScrollBarVisibility$ Visible=�5]   #   $��Visible=�6J   ��5[   #   �� *ExpenseTable.Items+ �� SelectedItem 5^   W   ��  �� Path$ SelectedExpenseItem�$ TwoWay=�   Columns 5_      0  *System.Windows.Controls.DataGridTextColumn  5`   "   ,  &System.Windows.Controls.DataGridColumn   Header$ Exp.ID��65      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6\   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *ID+6\     5a   "   $
 Date��65   $
 2.5* 6b    6C   �� *
DateString+6b     5b   "   $ Amount��65   $ 3* 6`    6E   �� *Amount+6`     5c   "   $	 Tag��65   $ 2* 6Z    6B   �� *Tag+6Z   5f      �� 5g      $��1��6#   $��Expense��60   $��5, 10, 200, 10q�6A   
�������.��5h      � $��30, 0, 0, 0q�6#    5i   "   �� 5j   &   $��1* �64   �� 5k   &   $��1* �64   �� 5l   &   $��1* �64   �� 5m   &   $��1* �64    5o   "   �� 5p   &   $��1* �67   �� 5q   &   $��2* �67   �� 5r   &   $
��1.2* �67   .+�5t   "   �� $��Date:��6,   $��0��69   $��0��6F   $��
5, 5, 5, 5q�6V   $��15(�6j   �� 5u   "   -   5        $	 textViewDate��5u   *   {�.  $��0��6�   $��1��6�   $��
5, 5, 5, 5q�6�   $��15(�6�   ��6@   �� * SelectedExpenseItem.DateString+6�   �� 5v   "   $��Amount:��6,   $��1��6;   $��0��6H   $��
5, 5, 5, 5q�6X   $��15(�6l   �� 5w   "   -   5        $	 textViewAmount��5w   *   $��1��6{   $��1��6�   $��
5, 5, 5, 5q�6�   $��15(�5x   *   ��5w   B   �� *SelectedExpenseItem.Amount+$ OneWay=�{�5x   8   �� *
IsSelected+$ TwoWay=��� 5y   "   $
��Tag:��6,   $��2��68   $��0��6E   $��
5, 5, 5, 5q�6U   $��15(�6i   �� 5z   "   -   5        $	 textViewTag��5z   *   $��2��6u   $��1��6�   $��
5, 5, 5, 5q�6�   $��15(�5{   *   ��5z   ?   �� *SelectedExpenseItem.Tag+$ OneWay=�{�5{   8   �� *
IsSelected+$ TwoWay=��� 5|   "   $��0��6-   $��4��6:   $��2��6K   $ Vertical=�6[   .+�5}   &   �� $ 
Horizontal=�61   .+�5~   *   �� $��Exp. No:��64   $��
0, 5, 5, 5q�6D   �� 5   *   -   5        $	 textViewExpID��5   2   {�.  $��50��6[   $��10, 5, 5, 5q�6i   ��5�   2   �� *SelectedExpenseItem.ID+$ OneWay=�5�   '   �� 5�   &   -   5        $ buttonViewUpdate��5�   -   $��Update��6G   $��15(�6X   $��5, 25, 5, 5q�6f   {�5�   -   �� *
IsSelected+$ TwoWay=��� 5�   &   -   5        $ buttonViewDelete��5�   -   $��Delete��6G   $��15(�6X   $��
5, 5, 5, 5q�6f   {�5�   -   �� *
IsSelected+$ TwoWay=�5�   #   5�      5�      5�      5�      �� 5�      $��
Statistics��6   .��5�      � $��0, 10, 0, 0q�6    5�      �� 5�      $��30 �6,   �� 5�      $��* �6,   .+�5�      �� $ 
Horizontal=�6%   .+�5�      �� -   5        $��0��5�   '   $	��Top=�5�   '   $	��120��6?   ��5�   4   ��  �� ElementName$ expenseWindow��$ Months� �� 	Converter# [   �� SelectedIndex 5�   K   �� *Statis.SelectedMonth+6z   �� 5�      $��Total:��6(   $��50,5,5,5q�66   �� 5�      -   5        $	 statisTextTotal��5�   &   $��5,5,5,5q�6]   $	��100��6n     �� 
IsReadOnly  . ��6?   �� *Statis.Total+6z   5�        OxyPlot.Wpf.PlotView  5�      -   5        !  Name$! plotView��5�   '   $��1��69   $
��auto��6x   $	��400��6�   "   Model" 6F   �� *Statis.XYPlotModel+$ OneWay=�6�   5�      5�      5�      �� 5�      $��1��6   $��2��6&   $ Vertical=�66   $��
5, 5, 5, 5q�6M   .+�5�      �� $��Today's Date��6   $��20(�60   &	   System.Windows.Controls.Calendar	  5�      $	��Top=�6   $
��Auto��63   $��
0, 5, 5, 5q�6@   $
��Left=�6T   5�      5�      5�      5�      