   M S B A M L   `   `   `  ����L  HSchereSteinPapier, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:SchereSteinPapierSchereSteinPapier  5   	   "    SchereSteinPapier.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:SchereSteinPapier     5   	     � Title$  Schere Stein Papier��5   	   $	��364��6%   $	��525��62   .��5	      � -   5        $��MainGrid��5	      $��10,0,2,2q�6    � RowDefinitions 5
   
   �� 5      $��5* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $��3* �6   �� 5      $	��10* �6   �� 5      $��10 �6    � ColumnDefinitions 5   
   �� 5      $��0.667 �6   �� 5      $��9.333 �6   �� 5      $	��10* �6   �� 5      $��10 �6   �� 5      $	��10* �6   �� 5      $��10 �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $��10 �6   �� 5      $	��10* �6   �� 5      $��10 �6   �� 5      $	��10* �6   �� 5       $��10 �6   .+�5"   
   �� -   5         ��Name$ 	Scissors1��5"      $��./Images/scissors.jpg��6#   $��Stretch=�6B   $��0,0,0,0q�6`   $��Stretch=�6q   $��2��6�   $��1��6�   �� 5#   
   -   5        $ Stone1��5#      $��./Images/Stone.jpg��6    $��Stretch=�6<   $��0,0,0,0q�6Z   $��Stretch=�6k   $��2��6�   $��2��6�   �� 5$   
   -   5        $ Paper1��5$      $��./Images/Paper.jpg��6    $��Stretch=�6<   $��0,0,0,0q�6Z   $��Stretch=�6k   $��2��6�   $��3��6�   $��2��6�   $��3��6�   	� 5&   
   -   5         	�Name$ rbScissors1��5&   %    	� 	GroupName$ P1��6   $��Scissors��6:   $
��Left=�6M   $��Center=�6h   $��	0,26,0,25q�6�   $��4��6�   $��1��6�   {�.  6�   	� 5'   
   -   5        $ rbStone1��5'   %   $ P1��6   $��Stone��67   $
��Left=�6G   $��Center=�6b   $��	0,25,0,26q�6}   $��4��6�   $��2��6�   {�.  6�   	� 5(   
   -   5        $ rbPaper1��5(   %   $ P1��6   $��Paper��67   $
��Left=�6G   $��Center=�6b   $	��0,2q�6}   $��4��6�   $��4��6�   {�.  6�   �� 5*   
   -   5         ��Name$ btnConfirm1��5*      $ ��Confirm selection Player 1��6&   {�.  $��Stretch=�6]   $��Stretch=�6{   $��0,0,0,0q�6�   $��6��6�   $��3��6�   $��2��6�   �� 5,   
   -	   5        $ 	Scissors2��5,      $��./Images/scissors.jpg��6#   $��Stretch=�6B   $��0,0,0,0q�6`   $��Stretch=�6q   $��11��6�   $��1��6�   �� 5-   
   -
   5        $ Stone2��5-      $��./Images/Stone.jpg��6    $��Stretch=�6<   $��0,0,0,0q�6Z   $��Stretch=�6k   $��11��6�   $��2��6�   �� 5.   
   -   5        $ Paper2��5.      $��./Images/Paper.jpg��6    $��Stretch=�6<   $��0,0,0,0q�6Z   $��Stretch=�6k   $��11��6�   $��3��6�   $��3��6�   	� 5/   
   -   5        $ rbScissors2��5/   %   $ P2��6   $��Scissors��6:   $
��Left=�6M   $��Center=�6h   $��	0,26,0,25q�6�   $��9��6�   $��1��6�   {�.  6�   	� 50   
   -   5        $ rbStone2��50   %   $ P2��6   $��Stone��67   $
��Left=�6G   $��Center=�6b   $��	0,25,0,26q�6}   $��9��6�   $��2��6�   {�.  6�   	� 51   
   -   5        $ rbPaper2��51   %   $ P2��6   $��Paper��67   $
��Left=�6G   $��Center=�6b   $	��0,2q�6}   $��9��6�   $��4��6�   {�.  6�   �� 53   
   -   5        $ btnConfirm2��53      $ ��Confirm selection Player 2��6&   {�.  $��Stretch=�6]   $��Stretch=�6{   $��0,0,0,0q�6�   $��6��6�   $��5��6�   $��2��6�   �� 55   
   -   5         ��Name$ 
lblPlayer1��55      $��Player 1��6$   $
��Left=�67   $��0,0,0,0q�6R   $��Bottom=�6c   $��2��6~   $��26��6�   $��52��6�   �� 56   
   -   5        $ 
lblPlayer2��56      $��Player 2��6$   $��Right=�67   $��0,0,0,0q�6S   $��Bottom=�6d   $��11��6   $��1��6�   $��26��6�   $��52��6�   �� 58   
   -   5        $ btnPlay��58      $
��Play��6"   $��Stretch=�61   $��Stretch=�6O   $��10,10,10,10q�6k   $��6��6�   $��2��6�   $��2��6�   {�.  6�   �� 5:   
   -   5        $ lblPlayer1Wins��5:      $��	Player 1:��6(   $��Right=�6<   $��Center=�6X   $��6��6s   $��1��6�   $��	0,20,0,21q�6�   �� 5;   
   -   5        $ lblPlayer2Wins��5;      $��	Player 2:��6(   $��Right=�6<   $��Bottom=�6X   $��6��6s   $��1��6�   �� 5<   
   -   5        $ lblWins��5<      $��Wins:��6!   $
��Left=�61   $	��Top=�6L   $��7��6d   $��1��6t   �� 5=   
   -   5        $ lblPlayer1WinsCount��5=      $��0��6-   $
��Left=�69   $��Center=�6T   $��7��6o   $��1��6   $��	0,20,0,21q�6�   �� 5>   
   -   5        $ lblPlayer2WinsCount��5>      $��0��6-   $
��Left=�69   $��Bottom=�6T   $��7��6o   $��1��6   �� 5@   
   -   5        $ 	lblBestOf��5@      $��Best of:��6#   $��Right=�66   $��Bottom=�6R   $��6��6m   $��0��6}   �� 5A   
   -   5         ��Name$ txtBestOfCount��5A      $��Stretch=�6*   $��23��6H   	 �� TextWrapping$
	 Wrap=�6T   $��7��6h   $��Bottom=�6x   $��0��6�   6�   �� 5C   
   -   5        
 ��Name$
 BorderPlayer1��5C      
���   �$��3q�6<   $��0��6P   $��Stretch=�6`   $��1��6~   $��5��6�   $��Stretch=�6�   $��4��6�   $y�Hidden=�6�   �� 5D   
   -   5        $
 BorderPlayer2��5D      
���   �$��3q�6<   $��10��6P   $��Stretch=�6a   $��1��6   $��5��6�   $��Stretch=�6�   $��3��6�   $y�Hidden=�6�   G� 5F   
   -   5         G�Name$ pbSelectionPlayer1��5F      $��Stretch=�62   $��Bottom=�6P   $��0��6k   $��4��6x    G� 	MaxLength$ 1��6�   $y�Hidden=�6�   6�   G� 5G   
   -   5        $ pbSelectionPlayer2��5G      $��Stretch=�62   $��Bottom=�6P   $��0��6k   $��9��6x   $ 1��6�   $y�Hidden=�6�   6�   �� 5I   
   -   5        $ lblChoseLetter1��5I      $��Stretch=�6)   $��Bottom=�6G   $��0��6b   $��4��6o   $��	Letter P1��6   �� 5J   
   -   5        $ lblChoseLetter2��5J      $��Stretch=�6)   $��Bottom=�6G   $��0��6b   $��9��6o   $��	Letter P2��6   �� 5L   
   -    5        $ txtScissors1��5L      $��Center=�6(   $��Stretch=�6C    �� 	MaxLength$ 1��6a   $��1��6o   $��4��6|   $��	0,23,0,22q�6�   6�   �� 5M   
   -!   5        $ 	txtStone1��5M      $��Center=�6%   $��Stretch=�6@   $ 1��6^   $��2��6m   $��4��6z   $��	0,23,0,22q�6�   6�   �� 5N   
   -"   5        $ 	txtPaper1��5N      $��Center=�6%   $��Stretch=�6@   $ 1��6^   $��4��6m   $��4��6z   6�   �� 5P   
   -#   5        $ txtScissors2��5P      $��Center=�6(   $��Stretch=�6C   $ 1��6a   $��1��6o   $��9��6|   $��	0,23,0,22q�6�   6�   �� 5Q   
   -$   5        $ 	txtStone2��5Q      $��Center=�6%   $��Stretch=�6@   $ 1��6^   $��2��6l   $��9��6y   $��	0,23,0,22q�6�   6�   �� 5R   
   -%   5        $ 	txtPaper2��5R      $��Center=�6%   $��Stretch=�6@   $ 1��6^   $��4��6l   $��9��6y   6�   5U      5V      