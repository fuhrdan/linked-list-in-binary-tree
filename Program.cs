//*****************************************************************************
//** 1367 Linked List in Binary Tree  leetcode                               **
//*****************************************************************************
//** Two solutions here, one using a helper function.  They are both the     **
//** roughly the same speed.    -Dan                                         **
//*****************************************************************************


/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     struct ListNode *next;
 * };
 */
/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     struct TreeNode *left;
 *     struct TreeNode *right;
 * };
 */
// Define the size of the stack
#define STACK_SIZE 1000

// Helper function to check if the path matches starting from the current tree node
bool dfs(struct TreeNode* root, struct ListNode* head) {
    // Base cases
    if (head == NULL) return true;  // If we've reached the end of the list
    if (root == NULL) return false; // If we've reached a null tree node

    // Check if the current node matches the list node value
    if (root->val != head->val) return false;

    // Recursively check left and right subtrees for the next list node
    return dfs(root->left, head->next) || dfs(root->right, head->next);
}

bool isSubPath(struct ListNode* head, struct TreeNode* root) {
  
    if (!head || !root) return false;

/*
    // Create manual stacks for tree and list nodes
    struct TreeNode* treeStack[STACK_SIZE];
    struct ListNode* listStack[STACK_SIZE];
    
    int treeStackTop = -1;
    int listStackTop = -1;

    // Push root onto the stack
    treeStack[++treeStackTop] = root;

    while (treeStackTop >= 0) 
    {
        struct TreeNode* currentNode = treeStack[treeStackTop--]; // Pop from tree stack

        // Check if the current tree node matches the head of the linked list
        if (currentNode->val == head->val) 
        {
            listStack[++listStackTop] = head; // Push head onto list stack
            treeStack[++treeStackTop] = currentNode; // Push current tree node again

            while (listStackTop >= 0) 
            {
                struct ListNode* currentListNode = listStack[listStackTop--]; // Pop from list stack
                struct TreeNode* currentTreeNode = treeStack[treeStackTop--]; // Pop from tree stack

//                printf("currentList = %d  currentTree = %d",currentListNode->val,currentTreeNode->val);
                // Add a check for NULL
                if (currentListNode == NULL || currentTreeNode == NULL)
                {
                    continue;
                }
                // If values don't match, break the current loop
                if (currentListNode->val != currentTreeNode->val) 
                {
                    continue;
                }

                // If we reached the end of the linked list, we have found a sub-path
                if (currentListNode->next == NULL) 
                {
                    return true;
                }

                // If there is a right child, continue to explore the right subtree
                if (currentTreeNode->right != NULL) 
                {
                    listStack[++listStackTop] = currentListNode->next; // Push next list node
                    treeStack[++treeStackTop] = currentTreeNode->right; // Push right tree node
                }

                // If there is a left child, continue to explore the left subtree
                if (currentTreeNode->left != NULL) 
                {
                    listStack[++listStackTop] = currentListNode->next; // Push next list node
                    treeStack[++treeStackTop] = currentTreeNode->left; // Push left tree node
                }
            }
        }

        // Push right and left children of the current tree node onto the stack
        if (currentNode->right != NULL) 
        {
            treeStack[++treeStackTop] = currentNode->right;
        }
        if (currentNode->left != NULL) 
        {
            treeStack[++treeStackTop] = currentNode->left;
        }
    }

    // If no sub-path is found
    return false;
*/
    // Check if there's a matching path from the current node or its subtrees
    return dfs(root, head) || isSubPath(head, root->left) || isSubPath(head, root->right);
}