   M S B A M L   `   `   `  ����#  purevanillymatnenaushilasshitat0    *purevanillymatnenaushilasshitat.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$#  Каталог товаров��5   	   $	��600��6!   $	��850��6.   
������� � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       �� 5   
   " ��6   .�5      ��  � ��$ Century Gothic)�6+   �� 5	       � ��$ 14(�6)   �� 5
       � ��$	 5,2q�6'   �� 5       � ��$
 Wrap=�6-   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��70 �6   �� 5      $
��Auto �6   �� 5      �� 5      $��30 �6   .+�5   
   �� ���#90EE90$��0��6&   ._�5      �  � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $
��Auto �6'   �� 5      $
��Auto �6'   .+�5       �� $#��Каталог товаров��6   $��Center=�5!      $��Center=�5"      $��24(�5#      $
��Bold"�5$      
���   �5%      �� 5'      $��0��6    �� Orientation$ Vertical=�6-   $��10,0,0,0q�6D   $��Center=�6V   .+�5(      �� -   5         ��Name$ LoginTextBlock��5(       $��Логин: ��68   $y�	Collapsed=�6G   $
��Bold"�6^   �� 5)      -   5        $ RoleTextBlock��5)       $��
Роль: ��67   $y�	Collapsed=�6E   5*      �� 5,      -   5        	 ��Name$	 
AuthButton��5,      $��
Войти��5-   	   $��80��5.   	   $��30��5/   	   $��
10,10,5,10q�50   	   $��Right=�51   	   $��Center=�52   	   $��1��53   	   54   	   �� 56      -   5        $	 RegisterButton��56      $��Регистрация��57   	   $	��100��58   	   $��30��59   	   $��
5,10,10,10q�5:   	   $��Right=�5;   	   $��Center=�5<   	   $��2��5=   	   5>   	   �� 5@      -   5        $	 LogoutButton��5@      $��
Выйти��5A   	   $	��100��5B   	   $��30��5C   	   $��
5,10,10,10q�5D   	   $��Right=�5E   	   $��Center=�5F   	   $��2��5G   	   $y�	Collapsed=�5I   	   5K      5L      ]� 5N   
   $��1��6   $��10q�6!   .+�5P      �� $ Vertical=�6   $	��200��60   .+�5Q      �� $,��&Фильтрация по скидке��6   �� 5R      -   5        $��DiscountFilterCB��5R      .@�5S      �� $��Все скидки��6#   
 �� 
IsSelected$

 True��68   �� 5T      $��0% - 4%��6#   �� 5U      $��5% - 7%��6#   5V      5X      �� 5Z      $ Vertical=�6   $��0,0,0,0q�60   $��Right=�6A   .+�5[      �� $��
Поиск��6   �� 5\      -   5        $��SearchTB��5\      $	��200��6*   66   5]      5^      �� 5`   
   $��2��6   .��5a      �� -   5        $��TovarLB��5a      
�������$��0q�5c      $��Stretch=�5d      ��5e      �� 5f      .R�5g      �� 
���   �$��1q�65   $��5q�6I   ._�5h      � $��5q�6#    5i   "   �� 5j   &   $	��150 �67   �� 5k   &   $��* �67   �� 5l   &   $��70 �67   .+�5o   "   �� 
�������$��1q�6A   $��0��6U   $��5q�6e   ._�5p   &   �� $��Uniform=�6G   $��5q�6Y   ��6,   �� *	Picture+6Y   5q   #   �� 5s   "   
�������$��1q�6A   $��1��6U   $��5q�6e   ._�5t   &   �� $��10q�61   .+�5u   *   �� $
��Bold"�6R   $��18(�6d   ��64   �� *Naimenovanie+6d   �� 5v   *   ��64   �� *Category_tovara+ �� StringFormat$* $Категория товара: {0}���� 5w   *   ��64   �� *
Opisanie+$( "Описание товара: {0}���� 5x   *   $��0,10,0,0q�6o   ��64   �� *Price+$% Стоимость: {0} руб.��6o   5y   '   5z   #   �� 5|   "   
�������$��1q�6A   $��2��6U   $��5q�6e   ._�5}   &   �� 
��� E��$��20(�5   (   $
��Bold"�5�   (   $��Center=�5�   (   $��Center=�5�   (   ��5}   0   �� *Deistvyushay_sale+$  {0} %��5�   (   5�   #   5�      5�      5�      5�      5�      �� 5�   
   -	   5        $��CountTextBlock��5�      $��3��5�      $��Right=�5�      $��10q�5�      $
��Bold"�5�      5�      5�      