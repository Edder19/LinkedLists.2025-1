using DoubleList;

var list = new DoublyLinkedList<string>();
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
                list.InsertSorted(dataAtBeginning); 
            }
            break;

        case "2":
            Console.Write("Enter the data to insert at the end: ");
            var dataAtEnd = Console.ReadLine();
            if (dataAtEnd != null)
            {
                
                list.InsertSorted(dataAtEnd); 
            }
            break;

        case "3":
            Console.WriteLine("Show list forward:");
            Console.WriteLine(list.GetForward());
            break;

        case "4":
            Console.WriteLine("Show list backward:");
            Console.WriteLine(list.GetBackward());
            break;


        case "5":
            Console.Write("Enter the data to remove: ");
            var remove = Console.ReadLine();
            if (remove != null)
            {
                list.RemoveAllOccurrences(remove);
                Console.WriteLine("Item removed.");
            }
            break;

        case "6":
            Console.Write("Enter data to insert in order: ");
            var sortedData = Console.ReadLine();
            if (sortedData != null)
            {
                list.InsertSorted(sortedData);
            }
            break;

        case "7":
            list.SortDescending();
            Console.WriteLine("List sorted in descending order.");
            break;

        case "8":
            var modes = list.GetModes();
            Console.WriteLine("Mode(s): " + string.Join(", ", modes));
            break;

        case "9":
            Console.WriteLine("Frequency Graph:");
            list.DisplayFrequencyGraph();
            break;

        case "10":
            Console.Write("Enter element to search: ");
            var search = Console.ReadLine();
            if (search != null)
            {
                Console.WriteLine(list.Exists(search)
                    ? $"The element '{search}' exists in the list."
                    : $"The element '{search}' does not exist in the list.");
            }
            break;

        case "11":
            Console.Write("Enter data to remove first occurrence: ");
            var removeOne = Console.ReadLine();
            if (removeOne != null)
            {
                Console.WriteLine("Removing first occurrence not implemented; removing all instead.");
                list.RemoveFirstOccurrence(removeOne);
            }
            break;

        case "12":
            Console.Write("Enter data to remove all occurrences: ");
            var removeAll = Console.ReadLine();
            if (removeAll != null)
            {
                list.RemoveAllOccurrences(removeAll);
                Console.WriteLine("All occurrences removed.");
            }
            break;
    }
}
while (opc != "0");

string Menu()
{
    Console.WriteLine("1. Insert at beginning ");
    Console.WriteLine("2. Insert at end ");
    Console.WriteLine("3. Show list forward");
    Console.WriteLine("4. Show list backward");
    Console.WriteLine("5. Remove");
    Console.WriteLine("6. Insert in sorted order");
    Console.WriteLine("7. Sort descending");
    Console.WriteLine("8. Show mode(s)");
    Console.WriteLine("9. Show frequency graph");
    Console.WriteLine("10. Check existence");
    Console.WriteLine("11. Remove first occurrence ");
    Console.WriteLine("12. Remove all occurrences");
    Console.WriteLine("0. Exit");
    Console.Write("Choose an option: ");
    return Console.ReadLine() ?? "0";
}