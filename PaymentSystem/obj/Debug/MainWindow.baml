   M S B A M L   `   `   `  ����H  DPaymentSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PaymentSystemPaymentSystem  5   	       PaymentSystem.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:PaymentSystem     5   	     � Title$  Autorization��5   	    � SizeToContent$ WidthAndHeight=�6    � WindowStartupLocation$ CenterScreen=�6=   .��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      $��20 �6   �� 5      $��20 �6   �� 5      $��20 �6   �� 5      $��20 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   Name:6(   �� 5   
   -   5        $��userBox��5      $��1��6   $	��250��6.   $��Italic$�6=   .��6P   Name6V   �� 5   
   $��2��6   	Password:6,   G� 5   
   -   5        $��passwordBox��5   4   $��3��6    G� PasswordChar$ *��6#   $	��250��6H    G� Password$
 1234��6W   � 5   
   $��4��6   $��Center=�6!   $��0,10,0,0q�6>   .+�5      �� -   5         �� 	IsDefault . $��60��5   :   $��0,0,10,0q�6H   .��6Z   	Sign in6c   �� 5      -   5        $��60��5   (   $��0,0,10,0q�66   .��6H   New Account6U   �� 5      -   5        $��60��5      .��67   Administrator6F   5      �� 5   
   -   5        $��5��5      $��Generate��6   $��5q�6F   $y�	Collapsed=�6Q   5      5      