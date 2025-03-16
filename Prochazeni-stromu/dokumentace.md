	Projekt - Prohlížení obchodní sítì
Úèel tohoto programu je spravovat zamìstnance obchodní sítì. Uživatel mùže procházet prohlížeè všech 
zamìstnancù, a nebo vytvoøit seznam, do kterého mùže pøidávat i odebírat zamìstnance. Seznam si mùže také uložit.

	Tøída Program
Hlavní tøída programu, která má na starosti vykreslování uživatelského rozhraní pro práci se seznamem obchodníkù.
Také umožòuje navigaci mezi obchodníky a ovládání programu pomocí kurzorových šipek (pøeklikávání mezi danými tlaèítky),
mezerníku (výbìr tlaèítka).
Inicializuje kurzory, strom obchodníkù a seznam.Renderuje uživatelské rozhraní pomocí tøídy Render. 
Má dvì rùzné navigace - jednu pro prohlížeè a druhou pro seznam.

	Tøída Render
Tøída zodpovídající za správné vykreslení uživatelského rozhraní. Poskytuje metody pro vykreslení 
hlavního rozhraní s informacemi o obchodníkovi, seznamu obchodníkù a také pro vykreslování podøízených 
obchodníkù a jejich prodejù.
Metoda RenderIF vykresluje hlavní obrazovku s informacemi o aktuálním obchodníkovi, 
jeho nadøízených, podøízených a prodeje.
Metoda RenderList vykresluje seznam obchodníkù.
Poslední metoda, GetTotalSalesRecursive, spoèítá celkové prodeje všech obchodníkù pod daným obchodníkem.

	Tøída Cursor
Tato tøída ruèí za správu kurzoru v uživatelském rozhraní.
Má vlastnosti X a Y, každá urèující pozici kurzoru.
Také má metodu FixCursorPosition, která opraví pozici kurzoru, pokud se seznam obchodníkù zmìní.

	Tøída Salesman
Tato tøída reprezentuje jednotlivé obchodníky a všechny jejich údaje, vèetnì jejich podøízených. 
Má vlastnosti: 
ID - každý obchodník ma unikátní ID
Name - jméno obchodníka
Surname - pøíjmení obchodníka
Sales - poèet prodejù urèitého obchodníka
Subordinates - seznam podøízených daného obchodníka


	Tøída Tree
Reprezentuje hierarchii obchodníkù. Udržuje koøen, aktuálnì zobrazeného obchodníka a zásobník pro navigaci
mezi obchodníky.
Má vlastnosti:
Node - aktuálnì zobrazený obchodník
Root - koøenový obchodník (šéf)
Stack - zásobník pro historii zobrazených obchodníkù
List - seznam obchodníkù pøidaných do seznamu

	Tøída List
Zodpovìdná za seznam obchodníkù. Umožòuje pøidávat (metoda AddSalesman), odstròovat(RemoveSalesman) obchodníky, 
ukládat (SaveList) a naèítat (LoadList) seznamy  obchodníkù se seznamu a také varovat uživatele 
o neuložených zmìnách (ListWarning). Dále má metodu CreateList, která vytvoøí nový seznam
 



