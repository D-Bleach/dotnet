   M S B A M L   `   `   `  ����?  ;Bai1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Bai1Bai1  5   	       Bai1.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Bai1     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5
      � .+�5   
   �� $��Mã bệnh nhân��6   $
��Left=�6'   $��28��6B   $��	27,46,0,0q�6N   $	��Top=�6a   $��92��6y   �� 5   
   -   5         ��Name$ txtMBN��5   >      CustomTextBoxStyle#��[  6   $
��Left=�6N   $��28��6i   $��
156,46,0,0q�6u    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��203��6�   �� 5   
   $��	Họ tên��6   $
��Left=�6!   $��28��6<   $��	39,92,0,0q�6H   $	��Top=�6[   $��69��6s   �� 5   
   -   5        $ txtHoTen��5      $
��Left=�6$   $��28��6?   $��
156,92,0,0q�6K   $
 Wrap=�6_   $	��Top=�6s   $	��203��6�   �� 5   
   $��Số ngày nằm viện��6   $
��Left=�6+   $��28��6F   $��
27,136,0,0q�6R   $	��Top=�6f   $	��112��6~   �� 5   
   -   5        $ txtNgay��5      $
��Left=�6#   $��28��6>   $��156,136,0,0q�6J   $
 Wrap=�6_   $	��Top=�6s   $	��203��6�   �� 5   
   $
��Khoa��6   $
��Left=�6   $��28��6:   $��
39,177,0,0q�6F   $	��Top=�6Z   $��69��6r   �� 5   
   -   5         ��Name$ txtKhoa��5      $
��Left=�6$   $��29��6?   $��156,177,0,0q�6K   $	��Top=�6`   $	��203��6x    �� DisplayMemberPath$ TenKhoa��6�    �� SelectedValuePath$ MaKhoa��6�    �� SelectedIndex$ 0��6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgvQLBenhNhan��5      $
��Left=�6*   $	��109��6E   $��
74,225,0,0q�6R   $	��Top=�6f   $	��640��6~      AutoGenerateColumns$ False��6�   	   AlternatingRowBackground
	 �����
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã Bệnh Nhân��6&      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6U   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *MaBn+6U     5      $ 	Họ Tên��6%   $ * 6O    65   �� *HoTen+6O     5      $ 	Tên Khoa��6%   $ * 6S    67   �� *	TenKhoa+6S     5      $ Số ngày nằm viện��6%   $ * 6a    6?   �� *SoNgayNamVien+6a     5      $ Viện phí��6%   $ * 67    6A   �� *	VienPhi+5      �� 5   
   -   5         ��Name$ btnThem��5        
buttonthem#��[ 6"   $��Thêm��6I   $
��Left=�6X   $��32��6s   $��204,364,0,0q�6   $	��Top=�6�   $	��107��6�   6�   �� 5   
   -   5        $ btnTim��5      #��[ 6!   $
��Tìm��6H   $
��Left=�6V   $��31��6q   $��394,365,0,0q�6}   $	��Top=�6�   $	��124��6�   6�   5!      5"      