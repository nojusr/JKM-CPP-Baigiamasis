   M S B A M L   `   `   `  ����   Baigiamasis    Baigiamasis.Window1   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     $��558.5��$
��1051��$��0q�  � WindowStyle$  ThreeDBorderWindow=� � Title$) #Nekilnojamo Turto Apskaitos Sistema�� � WindowStartupLocation$ Manual=� � 
ResizeMode$ CanResizeWithGrip=�$
��1051��$��558.5��.���  � ColumnDefinitions �� .+��� $��10q�$;��5/Baigiamasis;component/Resources/#IBM Plex Sans Light)�$��13(�.@��� -    ��Name$ ob_tab��$��Objektai�����	#FFEBEEBE$
��-2,0q�.��� ���	#FFEBEEBE$��-2q�.+�&   System.Windows.Controls.DataGrid  -     Name$ objektai��$��
5,29,251,5q�   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ *    
IsReadOnly . 	   VerticalGridLinesBrush	 �	#FF9C9C9C
   HorizontalGridLinesBrush
 �	#FF9C9C9C���� *objektaiBinding+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��   Width$ 30 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *ID+  $ Adresas��   MinWidth$	 130Q� �� *	Address+  $ Kvadratūra��$ 60Q� �� *Kvad+  $ Nuoma��$ 60Q� �� *Nuoma+  $ Nuomininkas��$	 130Q� �� *Nuom+  $ Elektros op. ��$ 60Q� �� *Elek+  $ Dujū/šilumos op.��$ 60Q� �� *Duj+  $ Vandens op.��$ 60Q� �� *Vand+  $ Interneto op.��$ 60Q� �� *Int+�� $��
Paieška: ��$
��Left=�$��0,2,0,0q�$	��Top=� J� RenderTransformOrigin$ 0.073,0.074&��� -    ��Name$ 	ob_search��$
��Left=�$��22��$��61,4,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��182��$ 0.5,0.5&��� 
�������$	��404��$��0,28,5,0q����	#FF8C8E94$	��Top=�$��Right=�$	��241���� $��Pridėti objektą:��$��
0,29,124,0q�$	��Top=�$��Right=�$	��122�����	#FF3A3A3A$;��5/Baigiamasis;component/Resources/#IBM Plex Sans Light)�$
��Bold"��� -   $ ob_addr��$��23��$��	0,75,10,0q�$
 Wrap=�$�� ��$	��Top=�$��Right=�$	��231�����	#FFEAEAEA�� $��Adresas:��$��
0,56,124,0q�$	��Top=�$��Right=�$	��122��
���   �$��10(���Z� �� -    ��Name$ ob_nuomininkai��$��
0,202,10,0q�$	��Top=�$��Right=�$	��231���� -    ��Name$ ob_nuomininkai_label��$��Nuomininkas:��$��0,182,124,0q�$	��Top=�$��Right=�$	��122��
���   �$��10(���Z� �� -   $ ob_plot��$��23��$��
0,117,10,0q�$
 Wrap=�$�� ��$	��Top=�$��Right=�$	��231�����	#FFEAEAEA�� $��Plotas (m^2):��$��
0,98,124,0q�$	��Top=�$��Right=�$	��122��
���   �$��10(���Z� �� -   $ ob_void_label��$��Vandens operatorius:��$��0,224,124,0q�$	��Top=�$��Right=�$	��122��
���   �$��10(���Z� �� -	   $ ob_void��$��
0,244,10,0q�$	��Top=�$��Right=�$	��231���� -
   $ ob_doid_label��$!��Dujų/šilumos operatorius:��$��0,268,118,0q�$	��Top=�$��Right=�$	��128��
���   �$��10(���Z� �� -   $ ob_doid��$��
0,288,10,0q�$	��Top=�$��Right=�$	��231���� -   $ ob_eoid_label��$��Elektros operatorius:��$��0,310,118,0q�$	��Top=�$��Right=�$	��128��
���   �$��10(���Z� �� -   $ ob_eoid��$��
0,330,10,0q�$	��Top=�$��Right=�$	��231���� $��Interneto operatorius:��$��0,354,118,0q�$	��Top=�$��Right=�$	��128��
���   �$��10(���Z� �� -   $ ob_ioid��$��
0,374,10,0q�$	��Top=�$��Right=�$	��231���� -   $��Pridėti��$��
0,402,10,0q�$	��Top=�$��24��$��Right=�$��76���� -   $$��Keisti bendrijos mokesčius...��$��	248,4,0,0q�$	��Top=�$��22��$
��Left=�$	��177���� -   $#��Trinti pasirinktas eilutes...��$��	430,4,0,0q�$	��Top=�$��22��$
��Left=�$	��156���� -   $"��Keisti pasirinką eilutę...��$��	591,4,0,0q�$	��Top=�$��22��$
��Left=�$	��146���� -   $ 	ob_nkaina��$��23��$��
0,159,10,0q�$
 Wrap=�$�� ��$	��Top=�$��Right=�$	��231�����	#FFEAEAEA�� $��Nuomos kaina:��$��0,140,124,0q�$	��Top=�$��Right=�$	��122��
���   �$��10(���Z� �� -   $ n_tab��$��Nuomininkai��$��4q�$��	-1,0,-3,0q����	#FFDCEAC7.��� ���	#FFDCEAC7$��-2q�.+�  -   $ nuomininkai��$��
5,29,251,5q�$ *  . 	 �	#FF9C9C9C
 �	#FF9C9C9C����  �� Path$ NuomininkaiDataBinding��� $��
Paieška: ��$
��Left=�$��0,2,0,0q�$	��Top=�$ 0.073,0.074&��� -   $ n_search��$
��Left=�$��22��$��61,4,0,0q�$
 Wrap=�$	��Top=�$	��182���� 
�������$	��297��$��0,29,5,0q����	#FF8C8E94$	��Top=�$��Right=�$	��241���� $��Pridėti nuomininką:��$��	0,29,77,0q�$	��Top=�$��Right=�$	��169�����	#FF3A3A3A$;��5/Baigiamasis;component/Resources/#IBM Plex Sans Light)�$
��Bold"��� -   $ n_vard��$��23��$��	0,75,10,0q�$
 Wrap=�$�� ��$	��Top=�$��Right=�$	��231�����	#FFEAEAEA���	#FFABADB3�� -   $��Pridėti��$��
0,296,10,0q�$	��Top=�$��24��$��Right=�$��76���� $��Vardas:��$��
0,56,124,0q�$	��Top=�$��Right=�$	��122��
���   �$��10(���Z� �� -   $ n_pav��$��23��$��
0,114,10,0q�$
 Wrap=�$�� ��$	��Top=�$��Right=�$	��231�����	#FFEAEAEA�� $��	Pavardė:��$��
0,95,124,0q�$	��Top=�$��Right=�$	��122��
���   �$��10(���Z� �� -   $ n_telnr��$��23��$��
0,153,10,0q�$
 Wrap=�$�� ��$	��Top=�$��Right=�$	��231�����	#FFEAEAEA�� $��Telefono numeris: ��$��0,134,124,0q�$	��Top=�$��Right=�$	��122��
���   �$��10(���Z� �� -   $ n_email��$��23��$��
0,192,10,0q�$
 Wrap=�$�� ��$	��Top=�$��Right=�$	��231�����	#FFEAEAEA�� $��Elektroninis paštas: ��$��0,173,124,0q�$	��Top=�$��Right=�$	��122��
���   �$��10(���Z� �� -   $ n_asmkod��$��23��$��
0,230,10,0q�$
 Wrap=�$�� ��$	��Top=�$��Right=�$	��231�����	#FFEAEAEA�� $��Asmens kodas: ��$��0,211,124,0q�$	��Top=�$��Right=�$	��122��
���   �$��10(���Z� �� -   $ n_dekgyv��$��23��$��
0,268,10,0q�$
 Wrap=�$�� ��$	��Top=�$��Right=�$	��231�����	#FFEAEAEA�� $��Deklaruota gyvenvietė: ��$��0,249,124,0q�$	��Top=�$��Right=�$	��122��
���   �$��10(���Z� �� -   $%��Naikinti pasirinktas eilutes...��$��	248,4,0,0q�$	��Top=�$��22��$
��Left=�$	��168���� -   $#��Keisti pasirinktą eilutę...��$��	421,4,0,0q�$	��Top=�$��22��$
��Left=�$	��147���� -    $ o_tab��$��Operatoriai��$
��-2,0q����	#FFDCEAF1.��� ���	#FFDCEAF1$��-2q�.+�  -!   $ operatoriai��$��
5,29,251,5q�$ *  . 
 �	#FF9C9C9C	 �	#FF9C9C9C���� *OperatoriaiDataBinding+�� $��
Paieška: ��$
��Left=�$��0,2,0,0q�$	��Top=�$ 0.073,0.074&��� -"   $ o_search��$
��Left=�$��22��$��61,4,0,0q�$
 Wrap=�$	��Top=�$	��182���� 
�������$	��192��$��0,29,5,0q����	#FF8C8E94$	��Top=�$��Right=�$	��241���� $��Pridėti operatorių:��$��
0,29,124,0q�$	��Top=�$��Right=�$	��122�����	#FF3A3A3A$;��5/Baigiamasis;component/Resources/#IBM Plex Sans Light)�$
��Bold"��� -#   $ o_pav��$��23��$��	0,75,10,0q�$
 Wrap=�$�� ��$	��Top=�$��Right=�$	��231�����	#FFEAEAEA�� -$   $��Pridėti��$��
0,191,10,0q�$	��Top=�$��24��$��Right=�$��76���� $��Pavadininmas:��$��
0,56,124,0q�$	��Top=�$��Right=�$	��122��
���   �$��10(���Z� �� -%   $%��Naikinti pasirinktas eilutes...��$��	248,4,0,0q�$	��Top=�$
��Left=�$	��174��$��22���� -&   $#��Keisti pasirinktą eilutę...��$��	427,4,0,0q�$	��Top=�$
��Left=�$	��148��$��22���� -'   $ op_type_label��$��Operatoriaus tipas:��$��
0,98,124,0q�$	��Top=�$��Right=�$	��122��
���   �$��10(���Z� �� -(   $ o_rate��$��23��$��
0,163,10,0q�$
 Wrap=�$�� ��$	��Top=�$��Right=�$	��231�����	#FFEAEAEA�� $��Kaina:��$��0,144,124,0q�$	��Top=�$��Right=�$	��122��
���   �$��10(���Z� �� -)   $ o_tipas��$��
0,121,10,0q�$	��Top=�$��Right=�$	��231��.@��� $��Elektra���� $��Vanduo���� $��Dujos���� $��
Internetas���� -*   $ out_tab��$��	Išvestis��$��	-3,0,-1,0q�$��21��$��Bottom=����	#FFF0C4C4.��� ���	#FFF0C4C4$��-2q�.+��� ���	#FFF4F4F5$
��Left=�$��5,34,0,0q����	#FFABADB3$	��302��$	��247��$	��Top=��� -+   $ out_ob_label��$��Pasirinkti objektą:��$
��Left=�$	��Top=�$��0,4,0,0q��� -,   $ out_ob��$��116,6,227,0q�$	��Top=��� $	��kWh��$
��Left=�$��
157,86,0,0q�$	��Top=�$��27���� --   $ out_e��$��23��$��	10,88,0,0q�$
 Wrap=�$	��Top=�$
��Left=�$	��142���� -.   $ out_e_title��$��
Elektra ()��$
��Left=�$��5,61,0,0q�$	��Top=�$��27���� $	��MWh��$
��Left=�$��157,136,0,0q�$	��Top=�$��27���� -/   $ out_d��$��23��$��
10,138,0,0q�$
 Wrap=�$	��Top=�$
��Left=�$	��142���� -0   $ out_d_title��$��Dujos/šiluma ()��$
��Left=�$��	5,111,0,0q�$	��Top=�$��27���� $	��m^3��$
��Left=�$��157,186,0,0q�$	��Top=�$��27���� -1   $ out_v��$��23��$��
10,188,0,0q�$
 Wrap=�$	��Top=�$
��Left=�$	��142���� -2   $ out_v_title��$��	Vanduo ()��$
��Left=�$��	5,161,0,0q�$	��Top=�$��27���� -3   $ out_i_title��$��Internetas ()��$
��Left=�$��	5,216,0,0q�$	��Top=�$��27���� -4   $ out_e_title_Copy��$��Komunaliniai mokesčiai:��$
��Left=�$��5,34,0,0q�$	��Top=�$��27��$	��272��$;��5/Baigiamasis;component/Resources/#IBM Plex Sans Light)�$
��Bold"��� ���	#FFF4F4F5$��312,34,10,0q����	#FFABADB3$��29��$	��Top=��� -5   $ out_e_title_Copy1��$��Bendrijos mokesčiai:��$
��Left=�$��
312,34,0,0q�$	��Top=�$��27��$	��272��$;��5/Baigiamasis;component/Resources/#IBM Plex Sans Light)�$
��Bold"�  -6   $ out_bend��$��312,61,10,49q�$ *  J� IsManipulationEnabled .    SelectionUnit$
 Cell=�
 �	#FFABADB3	 �	#FFABADB3�� $	��Eur��$
��Left=�$��157,243,0,0q�$	��Top=�$��27���� -7   $ out_i��$��23��$��
10,245,0,0q�$
 Wrap=�$	��Top=�$
��Left=�$	��142�� �� SelectionBrush �	#FFABADB3{�.  �� -8   $$��Keisti bendrijos mokesčius...��$��0,6,45,0q�$	��Top=�$��23��$��Right=�$	��177���� -9    ��Name$ out_filebutton��$��0,6,10,0q�$	��Top=�$��23��$��Right=�$��30��$	��0,1q�.���� $��30�� �� Orientation$ 
Horizontal=�$��Center=�.+��� $��Resources/flat-folder.png��$��20��$��23��$
��Left=�$��3,0,0,0q��� -:   $��Kurti sąskaitą...��$��0,0,10,5q�$��16(�$
��Bold"�$��Right=�$	��207��$��39��$��Bottom=�