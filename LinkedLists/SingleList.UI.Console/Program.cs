using SingleList;

var singleList = new SinglyLinkedList<string>();
var opc = "0";
do
{
    opc = Menu();
    switch (opc)
    {
        case "1":
            Console.Write("Enter the data to insert at the beginning: ");
            var dataAtBeginning = Console.ReadLine();
            if (dataAtBeginning != null)
            {
                singleList.InsertAtBeginning(dataAtBeginning);
            }
            break;

        case "2":
            Console.Write("Enter the data to insert at the end: ");
            var dataAtEnd = Console.ReadLine();
            if (dataAtEnd != null)
            {
                singleList.InsertAtEnd(dataAtEnd);
            }
            break;

        case "3":
            Console.WriteLine(singleList.ToString());
            break;

        case "4":
            Console.Write("Enter the data to validate if exists: ");
            var data = Console.ReadLine();
            if (data != null)
            {
                var anwser = singleList.Contains(data) ? "exists" : "doesn't exists";
                Console.WriteLine($"The data: {data} {anwser}");
            }
            break;

        case "5":
            singleList.Clear();
            Console.Write("List cleaned.");
            break;

        case "6":
            Console.Write("Enter the data to remove: ");
            var remove = Console.ReadLine();
            if (remove != null)
            {
                if (singleList.Contains(remove))
                {
                    singleList.Remove(remove);
                    Console.WriteLine("Item removed.");
                }
                else
                {
                    Console.WriteLine("Item doesn't exists.");
                }
            }
            break;

        case "7":
            singleList.Reverse();
            Console.WriteLine("List reversed.");
            break;

            
            case "8":
            singleList.SortAscending();
            Console.WriteLine("List sorted in ascending order.");
            break;

        case "9":
            singleList.SortDescending();
            Console.WriteLine("List sorted in descending order.");
            break;

    }
} while (opc != "0");

string Menu()
{
    Console.WriteLine("1. Insert at beginning");
    Console.WriteLine("2. Insert at end");
    Console.WriteLine("3. Show list");
    Console.WriteLine("4. Contains");
    Console.WriteLine("5. Clear all list");
    Console.WriteLine("6. Remove item");
    Console.WriteLine("7. Reverse");
    Console.WriteLine("0. Exit");
    Console.Write("Choose an option: ");
    return Console.ReadLine() ?? "0";
}