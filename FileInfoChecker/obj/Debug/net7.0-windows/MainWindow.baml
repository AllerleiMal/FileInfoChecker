   M S B A M L   `   `   `  ����J  FFileInfoChecker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:FileInfoCheckerFileInfoChecker  5   
   U QSystem.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3aO8clr-namespace:System.Collections;assembly=System.RuntimeSystem.Collections 5   
        FileInfoChecker.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   
   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   
   @d2http://schemas.microsoft.com/expression/blend/2008     5   
   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   
   /localclr-namespace:FileInfoChecker     5   
   Pcollections8clr-namespace:System.Collections;assembly=System.Runtime     5   
     � Title$  	File info��5	   
   $	��800��6   $	��800��6)   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   6.   �� 5      6!   .+�5   
   �� -   5        $��PathChooseButton��5   .   $��0��6   $��0��6   $��Choose path��6F   $
��10pxq�6\   6�   �� 5   
   -   5        $��CurrentPath��5   1   $��0��6   $��1��6!   $��No path chosen��6D    �� TextAlignment$ Center=�6Z    �� Padding$
 10pxq�6q   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	PhotoGrid��5      $��1��5      $��2��6    $��0��64   $��Stretch=�6D      CanUserSortColumns$
 True��5      $��Stretch=�5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5         CanUserResizeColumns$ False��5      	   AutoGenerateColumns$
	 True��5         DataGridStyle#��[  5      
 � 	Resources
 5      "  System.Collections.ArrayList  
PhotoInfos��%!   &	         5      5       5!      5"      5#      5$      