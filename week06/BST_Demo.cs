using System;

/// <summary>
/// Demo program to illustrate Binary Search Tree concepts from W06 Learning Activity
/// </summary>
public class BSTDemo
{
    public static void Main()
    {
        Console.WriteLine("=== W06 Binary Search Tree Demo ===\n");
        
        // Demo 1: Basic BST Operations
        Console.WriteLine("1. Creating BST with values: 15, 10, 24, 3, 14, 33");
        var bst = new BinarySearchTree();
        bst.Insert(15);  // Root
        bst.Insert(10);  // Left of 15
        bst.Insert(24);  // Right of 15
        bst.Insert(3);   // Left of 10
        bst.Insert(14);  // Right of 10
        bst.Insert(33);  // Right of 24
        
        Console.WriteLine($"BST (in-order): {bst}");
        Console.WriteLine($"Height: {bst.GetHeight()}");
        Console.WriteLine();
        
        // Demo 2: Traversal Types
        Console.WriteLine("2. Different Traversal Types:");
        Console.WriteLine($"In-order (Left→Root→Right): {bst}");
        Console.WriteLine($"Reverse (Right→Root→Left): {string.Join(", ", bst.Reverse().Cast<int>())}");
        Console.WriteLine();
        
        // Demo 3: Search Operations
        Console.WriteLine("3. Search Operations:");
        Console.WriteLine($"Contains 14: {bst.Contains(14)}");
        Console.WriteLine($"Contains 20: {bst.Contains(20)}");
        Console.WriteLine($"Contains 33: {bst.Contains(33)}");
        Console.WriteLine();
        
        // Demo 4: No Duplicates Rule
        Console.WriteLine("4. Testing No Duplicates Rule:");
        Console.WriteLine($"Before inserting duplicate 24: {bst}");
        bst.Insert(24);  // This should have no effect
        Console.WriteLine($"After inserting duplicate 24: {bst}");
        Console.WriteLine();
        
        // Demo 5: Balanced vs Unbalanced Trees
        Console.WriteLine("5. Balanced vs Unbalanced Trees:");
        
        // Unbalanced tree (inserting in sorted order)
        var unbalanced = new BinarySearchTree();
        int[] sortedValues = {3, 10, 14, 15, 20, 24, 33};
        foreach (var value in sortedValues)
        {
            unbalanced.Insert(value);
        }
        Console.WriteLine($"Unbalanced BST (inserted in order): {unbalanced}");
        Console.WriteLine($"Unbalanced height: {unbalanced.GetHeight()} (like a linked list!)");
        
        // Balanced tree using our algorithm
        var balanced = Trees.CreateTreeFromSortedList(sortedValues);
        Console.WriteLine($"Balanced BST (same values): {balanced}");
        Console.WriteLine($"Balanced height: {balanced.GetHeight()} (much better!)");
        Console.WriteLine();
        
        // Demo 6: Performance Difference Visualization
        Console.WriteLine("6. Performance Analysis:");
        Console.WriteLine($"For {sortedValues.Length} nodes:");
        Console.WriteLine($"- Unbalanced BST: O(n) = O({sortedValues.Length}) operations for search");
        Console.WriteLine($"- Balanced BST: O(log n) = O({Math.Ceiling(Math.Log2(sortedValues.Length))}) operations for search");
        Console.WriteLine();
        
        // Demo 7: Large Balanced Tree
        Console.WriteLine("7. Large Balanced Tree Example:");
        var largeBST = Trees.CreateTreeFromSortedList(Enumerable.Range(1, 127).ToArray());
        Console.WriteLine($"BST with 127 nodes (2^7 - 1)");
        Console.WriteLine($"Height: {largeBST.GetHeight()} - perfectly balanced!");
        Console.WriteLine($"Contains 64: {largeBST.Contains(64)}");
        Console.WriteLine($"Contains 100: {largeBST.Contains(100)}");
        Console.WriteLine();
        
        Console.WriteLine("=== Demo Complete ===");
        Console.WriteLine("\nKey Takeaways:");
        Console.WriteLine("• In-order traversal of BST gives sorted sequence");
        Console.WriteLine("• Balanced BST: O(log n) operations");
        Console.WriteLine("• Unbalanced BST: O(n) operations (worst case)");
        Console.WriteLine("• BST insertion order affects tree balance");
    }
}
