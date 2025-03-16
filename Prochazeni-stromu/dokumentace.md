	Projekt - Prohl�en� obchodn� s�t�
��el tohoto programu je spravovat zam�stnance obchodn� s�t�. U�ivatel m��e proch�zet prohl�e� v�ech 
zam�stnanc�, a nebo vytvo�it seznam, do kter�ho m��e p�id�vat i odeb�rat zam�stnance. Seznam si m��e tak� ulo�it.

	T��da Program
Hlavn� t��da programu, kter� m� na starosti vykreslov�n� u�ivatelsk�ho rozhran� pro pr�ci se seznamem obchodn�k�.
Tak� umo��uje navigaci mezi obchodn�ky a ovl�d�n� programu pomoc� kurzorov�ch �ipek (p�eklik�v�n� mezi dan�mi tla��tky),
mezern�ku (v�b�r tla��tka).
Inicializuje kurzory, strom obchodn�k� a seznam.Renderuje u�ivatelsk� rozhran� pomoc� t��dy Render. 
M� dv� r�zn� navigace - jednu pro prohl�e� a druhou pro seznam.

	T��da Render
T��da zodpov�daj�c� za spr�vn� vykreslen� u�ivatelsk�ho rozhran�. Poskytuje metody pro vykreslen� 
hlavn�ho rozhran� s informacemi o obchodn�kovi, seznamu obchodn�k� a tak� pro vykreslov�n� pod��zen�ch 
obchodn�k� a jejich prodej�.
Metoda RenderIF vykresluje hlavn� obrazovku s informacemi o aktu�ln�m obchodn�kovi, 
jeho nad��zen�ch, pod��zen�ch a prodeje.
Metoda RenderList vykresluje seznam obchodn�k�.
Posledn� metoda, GetTotalSalesRecursive, spo��t� celkov� prodeje v�ech obchodn�k� pod dan�m obchodn�kem.

	T��da Cursor
Tato t��da ru�� za spr�vu kurzoru v u�ivatelsk�m rozhran�.
M� vlastnosti X a Y, ka�d� ur�uj�c� pozici kurzoru.
Tak� m� metodu FixCursorPosition, kter� oprav� pozici kurzoru, pokud se seznam obchodn�k� zm�n�.

	T��da Salesman
Tato t��da reprezentuje jednotliv� obchodn�ky a v�echny jejich �daje, v�etn� jejich pod��zen�ch. 
M� vlastnosti: 
ID - ka�d� obchodn�k ma unik�tn� ID
Name - jm�no obchodn�ka
Surname - p��jmen� obchodn�ka
Sales - po�et prodej� ur�it�ho obchodn�ka
Subordinates - seznam pod��zen�ch dan�ho obchodn�ka


	T��da Tree
Reprezentuje hierarchii obchodn�k�. Udr�uje ko�en, aktu�ln� zobrazen�ho obchodn�ka a z�sobn�k pro navigaci
mezi obchodn�ky.
M� vlastnosti:
Node - aktu�ln� zobrazen� obchodn�k
Root - ko�enov� obchodn�k (��f)
Stack - z�sobn�k pro historii zobrazen�ch obchodn�k�
List - seznam obchodn�k� p�idan�ch do seznamu

	T��da List
Zodpov�dn� za seznam obchodn�k�. Umo��uje p�id�vat (metoda AddSalesman), odstr�ovat(RemoveSalesman) obchodn�ky, 
ukl�dat (SaveList) a na��tat (LoadList) seznamy  obchodn�k� se seznamu a tak� varovat u�ivatele 
o neulo�en�ch zm�n�ch (ListWarning). D�le m� metodu CreateList, kter� vytvo�� nov� seznam
 



