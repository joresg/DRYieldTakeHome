   M S B A M L   `   `   `  ????J  FDRYieldTakeHome, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:DRYieldTakeHome.UserControlsDRYieldTakeHome.UserControls  5      0    *DRYieldTakeHome.UserControls.Visualization   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:DRYieldTakeHome.UserControls     5      .??5	      ? ???#404252  ? RowDefinitions  5
   
   ?? 5      $??* ?6   ?? 5      $	??10* ?6   ?? 5      $??* ?6   ?? 5      $	??10* ?6   .+?5   
   ?? 
???  ??$??Center=?6C   $??Center=?6^   ??6   ??  ?? Path$ VisText?6^   ?? 5   
   -   5        $??MIRData??5   @   $??1??63   $??Visible=?6O   ??6   ?? *	MIRList+ ?? View 5      ?? 5      .P?5      ?? $??Lot ID??6%    ?? Width$ 50??65    ?? DisplayMemberBinding 6@   ?? *LOT_ID+?? 5      $??	Part type??6%   $ 60??68    6C   ?? *
PART_TYP+?? 5      $??Job name??6%   $ 60??67    6B   ?? *	JOB_NAM+?? 5      $??Node ID??6%   $ 60??66    6A   ?? *
NODE_NAM+?? 5      $??Tester Type??6%   $ 70??6:    6E   ?? *
TSTR_TYP+?? 5      $??
Setup time??6%   $	 120??69    6E   ?? *	SETUP_TYP+?? 5      $??
Start Time??6%   $	 120??69    6E   ?? *	START_T+?? 5      $??Operator Name??6%   $	 100??6<    6H   ?? *
OPER_NAM+?? 5      $??	Test Mode??6%   $ 60??68    6C   ?? *
MODE_COD+?? 5      $??Station Number??6%   $ 60??6=    6H   ?? *
STAT_NUM+?? 5      $??	Sublot ID??6%   $ 60??68    6C   ?? *
SBLOT_ID+?? 5      $??	Test Code??6%   $ 60??68    6C   ?? *
TEST_COD+?? 5       $??YIELD??6%   $ 60??64    6?   ?? *YIELD+5!      5#      ?? 5$   
   $??2??6   
???  ??$??Center=?6R   $??Center=?6m   ??6!   ?? $ 	paramText?6m   ?? 5%   
   -   5        $??	ParamData??5%   @   $??3??63   $??Visible=?6Q   ??6   ?? *	PTRList+ 5&      ?? 5'      .P?5(      ?? $??Chip number??6%   $	 100??6:    6F   ?? *CHIPN+?? 5)      $??	Parameter??6%   $ 60??68    6C   ?? *
TEST_TXT+?? 5*      $	??LSL??6%   $ 60??62    6=   ?? *	LO_SPEC+?? 5+      $	??USL??6%   $ 60??62    6=   ?? *	HI_SPEC+?? 5,      $
??MEAN??6%   $	 100??63    6?   ?? *MEAN+?? 5-      $??STANDARD DEVIATION??6%   $	 200??6A    6M   ?? *	STD_DEV+5.      50      51      52      