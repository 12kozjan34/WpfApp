   M S B A M L   `   `   `  ����B  >Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ProjectProject  5          Project.CoursePage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Project     5        N� Title$  EditCoursePage��5	      .��5      � -   5         �Name$
 grid��5      
�������.+�5   
   �� -   5         ��Name$ btnBack��5      $��52��5      $��25��6   
������ 
������ $
��Left=�5      $��	50,31,0,0q�6(   $	��Top=�6;    J� RenderTransformOrigin$ -0.604,0.494&�6S   .��5      �� -   5         ��Name$ image��5      $��/Assets/93634.png��5      5      �� 5   
   -   5         ��Name$ 	lvCourses��5      $��50,104,494,225q�6     �� AlternationCount$ 2��5      $ 0.484,0.582&�6"   ��5      �� 5       �� 
TargetType" ��6   .�5      -   5        �� 5       �� Property � ��	 �� Value
	 ��ح�63   
 �� Triggers
 5      P� 5       P� Property �@��AlternationIndex P� Value$ 1��6G   . �5       ��  � ��
	 �����6;   5!      ]� 5"       ]� 
Conditions 5#      �� 5$   "    �� Property �@��
IsSelected �� Value$
 True��6B   ./�5&      ��  � ��
	 ���_�6;   5'      5)       �� View 5+      �� 5,      .P�5-      ��  �� Width$	 126��6%   $��Course Name��61    �� DisplayMemberBinding 5.      �� *Name+�� 5/      $	 126��6%   $��Profesor��61    �� CellTemplate 50      �� 51      .R�52   "   ��  �� Orientation$ 
Horizontal=�6-   .+�53   &   �� $��0,0,5,0q�6T   ��60   �� *Profesor.FirstName+6T   �� 54   &   ��60   �� *Profesor.LastName+55   #   56      58      59      5;      �� 5=   
   -   5        $ btnAdd��5A      $	��Add��5>      
��� � �
�������$
��Left=�5C      $��112,249,0,0q�6    $	��Top=�65   $��84��6M   $��26��6X   �� 5D   
   -   5        $ 	btnDelete��5H      $��Delete��5E      
���  ��
�������$
��Left=�5J      $��220,249,0,0q�6    $	��Top=�65   $��83��6M   $��26��6X   5K      5L      