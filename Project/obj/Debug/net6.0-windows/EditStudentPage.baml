   M S B A M L   `   `   `  ����B  >Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ProjectProject  5          Project.EditStudentPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Project     5        N� Title$  EditStudentPage��5	      .��5      � -   5         �Name$
 grid��5      
����  �.+�5   
   �� -   5         ��Name$ pictureBorder��5      $	��200��5      $	��300��5      
�������$��1q�5      $��355,75,45,75q�6-   ._�5      �� -   5         ��Name$ picture��5   	   ��5   	   �� *Image+5      �� 5   
   $��
First Name��5      
�������$
��Left=�5      $��	50,75,0,0q�6#   $	��Top=�66   �� 5   
   -   5         ��Name$ tbFirstName��5   
   $
��Left=�5   
   $��
134,79,0,0q�6%    �� TextWrapping$
 Wrap=�69   $	��Top=�6M   $	��177��6e   ��5      �� *	FirstName+5   e   �� 5   
   $��	Last Name��5       
�������$
��Left=�5$      $��
50,125,0,0q�6    $	��Top=�64   �� 5%   
   -   5        $ 
tbLastName��5&      $
��Left=�5'      $��134,129,0,0q�6    $
 Wrap=�65   $	��Top=�6I   $	��177��6a   ��5%      �� *
LastName+5'   a   �� 5(   
   $	��Age��5)      
�������$
��Left=�5-      $��
50,178,0,0q�6    $	��Top=�64   �� 5.   
   -   5        $ tbAge��5/      
 � Tag$	 Int��50      $
��Left=�51      $��272,182,0,0q�6    $
 Wrap=�65   $	��Top=�6I   $��39��6a   ��5.      �� *Age+51   a   �� 52   
   $��Email��53      
�������$
��Left=�57      $��
50,231,0,0q�6    $	��Top=�64   �� 58   
   -   5        $ tbEmail��59      $ Email��5:      $
��Left=�5;      $��134,235,0,0q�6    $
 Wrap=�65   $	��Top=�6I   $	��177��6a   ��58      �� *Email+5;   a   �� 5<   
   -   5         ��Name$ btnBack��5?   	   $��52��5<      $��25��6   
������ 
������ $
��Left=�5A   	   $��	50,31,0,0q�6$   $	��Top=�67    J� RenderTransformOrigin$ -0.604,0.494&�6O   .��5B      �� -	   5        $ image��5B      $��/Assets/93634.png��5C      5D      �� 5E   
   -
   5        $ 	btnCommit��5I      $��Commit��5F      
���   �
�������$
��Left=�5M   	   $��
56,288,0,0q�6$   $	��Top=�68   $��23��6P   $��60��6\   �� 5N   
   -   5        $ 	btnUpload��5R      $��Upload��5O      
��� ���
�������$
��Left=�5V   	   $��251,288,0,0q�6$   $	��Top=�69   $��23��6Q   $��60��6]   5W      5X      