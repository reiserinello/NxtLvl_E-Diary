   M S B A M L   `   `   `  ����I  ENxtLvl_E-Diary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:NxtLvl_E_DiaryNxtLvl_E_Diary  5   	        NxtLvl_E_Diary.createEntry   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:NxtLvl_E_Diary     5   	     � Title$  createEntry��5   	   $��320.667��6   $	��442��6.   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      $��0* �6   �� 5      $��0* �6   .+�5   
   �� -   5         ��Name$ txtEntryText��5      $
��Left=�6(   $	��263��6C   $��	10,10,0,0q�6P    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��271��6�   �� 5   
   -   5         ��Name$ lblEntryTitle��5      $��Title:��6'   $
��Left=�68   $��
295,10,0,0q�6S   $	��Top=�6g   $��39��6   $��28��6�    J� RenderTransformOrigin$ 0.615,2.115&�6�   �� 5   
   -   5        $ txtEntryTitle��5      $
��Left=�6)   $��23��6D   $��
295,38,0,0q�6P   $
 Wrap=�6d   $	��Top=�6x   $	��114��6�   �� 5   
   -   5         ��Name$ btnSaveEntry��5      $
��Save��6'   $
��Left=�66   $��295,252,0,0q�6Q   $	��Top=�6f   $	��114��6~   $��21��6�   6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dtpEntryDate��5      $
��Left=�6+   $��
295,66,0,0q�6F   $	��Top=�6Z   $	��114��6r   �� 5   
   $��Types:��6   $
��Left=�6!   $��
295,96,0,0q�6<   $	��Top=�6P   $��72��6h   � 5   
   -   5         �Name$ grdTypes��5      $
��Left=�6!   $	��100��6<   $��295,127,0,0q�6I   $	��Top=�6^   $	��114��6v   .+�5      �� -   5        	 ��Name$	 ckbTypeFamily��5      $��Family��6.   $
��Left=�6?   $	��Top=�6Z   $��82��6r   6}   �� 5      -   5        $	 ckbTypeSport��5      $��Sport��6-   $
��Left=�6=   $��0,21,0,0q�6X   $	��Top=�6j   $��82��6�   6�   �� 5      -	   5        $	 ckbTypeWork��5      $
��Work��6,   $
��Left=�6;   $��0,42,0,0q�6V   $	��Top=�6h   $��82��6�   6�   �� 5      -
   5        $	 ckbTypeSchool��5      $��School��6.   $
��Left=�6?   $��0,63,0,0q�6Z   $	��Top=�6l   $��82��6�   6�   �� 5      -   5        $	 ckbTypeFriends��5      $��Friends��6/   $
��Left=�6A   $��0,84,0,0q�6\   $	��Top=�6n   $��82��6�   6�   5      5      5      