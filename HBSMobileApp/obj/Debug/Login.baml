   M S B A M L   `   `   `  ����G  CHBSMobileApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:HBSMobileAppHBSMobileApp  5   	       HBSMobileApp.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:HBSMobileApp     5   	     � Title$  HBS - Employee Login��5   	   $	��600��6&   $	��400��63   ���	#FFF9F2F2��5	      �� 5
   
    �� EndPoint$ 0.5,1&�6    � MappingMode$ RelativeToBoundingBox=�6/    �� 
StartPoint$ 0.5,0&�6S   .��5      �  � Color$ 	#FF172727��6   � 5      $ 	#FFF8FBFB��6    � Offset$ 0.973Q�6-   � 5      $ 	#FF1B3030��6   $
 0.25Q�6-   � 5      $ 	#FF375353��6   $ 0.483Q�6-   5      .��5      � -   5        $��myGrid��5       J� Opacity$	 0.7Q�6   $��Stretch=�6'   $��Stretch=�6E   $��0q�6a    � ColumnDefinitions 5   
   �� 5      $	��120 �6   6-   �� 5      $	��200 �6   6-    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� -   5        $
��txt1��5      $��22,10,57,21q�6    $��48(�65   $��Segoe UI Semibold)�6C   $��1��6b   $��0��6r   $��Center=�6   ���	#FFF8F9F2$
��Bold"�6�   $��Expanded&�6�   $��Center=�6�   Login6�   �� 5   
   -   5        $
��txt2��5      $��20(�6    $��Segoe UI Semibold)�6.   $��0��6M   $��2��6]   $��Center=�6j   $��Center=�6�   ���	#FFF8F9F2$
��Bold"�6�   $��Expanded&�6�   
Username6�   �� 5    
   -   5        $
��txt3��5       $��20(�6    $��Segoe UI Semibold)�6.   $��0��6M   $��3��6]   $��Center=�6j   $��Center=�6�   ���	#FFF8F9F2$
��Bold"�6�   $��Expanded&�6�   
Password6�   �� 5!   
   -   5        $��
errorBlock��5!      $��30(�6&   $��Segoe UI Semibold)�64   $��2��6S   $��4��6g   $��Center=�6t   $��Center=�6�   ���	#FFF90505$
��Bold"�6�   $��Expanded&�6�   	 �� Padding$
	 10,0q�6�   Error6  G� 5"   
   -   5        $��passwordBox��5"      $��
22,16,2,16q�6)   $��24(�6=   $��Segoe UI Semibold)�6K   $��2��6j   $��3��6z   
����������	#FF11435F$
��Bold"�6�   $��Center=�6�   $	��5,0q�6�   $��1��6�   6  �� 5#   
   -   5        $��usernameBox��5#      $��
22,16,2,16q�6%   $��24(�69   $��Segoe UI Semibold)�6G   $��2��6f   $��2��6v   
����������	#FF11435F$
��Bold"�6�   
 �� MaxLines$
 1��6�   $
��Left=�6�   $��Center=�6�   $	��5,0q�6  $��0��6  �� 5$   
   -   5        $��1��5$      $��5��6!   ���	#FF9E871B$
��Bold"�6F   $��36(�6X   
�������$��Center=�6y   $��Center=�6�   $
��35,1q�6�    � Cursor$
 Hand��6�   $��20,10,-30,13q�6�   $��2��6�   ��5&      �� 5'      $ 0.5,1&�6&   $ RelativeToBoundingBox=�67   $ 0.5,0&�6[   .��5(      � $ 	#FF63B022��6#   $	 0.1Q�65   � 5)      $ 	#FF43851E��6#   $ 1Q�65   5*      .��5+   !   Login5,      5-      5/      