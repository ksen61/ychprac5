   M S B A M L   `   `   `  ����C  ?PetShop7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PetShop7PetShop7  5          PetShop7.PurchasePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:PetShop7     5        N� Title$  PurchasePage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      �� 5      $
��0.2* �6   �� 5      $
��0.1* �6    � ColumnDefinitions 5   
   �� 5      �� 5      $
��0.1* �6   �� 5      .+�5   
   �� $��0��6   $��0��6   $��Bottom=�6-   $��Center=�6H   $��Все товары��6e   �� 5   
   -   5         ��Name$ 
PriceLabel��5      $��0��6$   $��2��61   $��Center=�6A   $��Bottom=�6^   $$��Итоговая сумма: 0��6y   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ ProductsDataGrid��5      $��1��6-   $��0��6:   6J   �� 5   
   $��1��6   $��1��6"   $��Center=�62   .+�5      �� -   5         ��Name$ 	AddButton��5      $��+��6(   $��0,0,0,20q�64   {�.  6X   �� 5      -   5        $ RemoveButton��5      $��-��6+   {�.  6I   5        5   
   -   5        $ SelectedDataGrid��5      $��1��6-   $��2��6:   6J   �� 5   
   $��2��6   $��3��6"   .+�5       �� $#��Клиент заплатил��6   �� 5!      -   5         ��Name$ 
PayTextBox��5!      5"      �� 5#   
   -   5        $ 
SaveButton��5#      $��3��6%   $��3��62   $3��-Сохранить и получить чек��6_   5$      5%      