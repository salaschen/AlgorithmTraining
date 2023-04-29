# 904 Fruit Into Baskets Medium
# Author: Ruowei Chen
# Date: 29/Apr/2023
# Note: Sliding window

class Solution:
    def totalFruit(self, fruits: [int]) -> int:
        fs = dict() 
        rightPtr = 1
        flen = len(fruits)
        if flen == 0:
            return 0
        types = 1
        fs[fruits[0]] = 1
        result = 1
        for i in range(flen):
            # remove the previous number
            if i > 0: 
                prev = fruits[i-1]
                fs[prev] -= 1
                if fs[prev] == 0:
                    types -= 1
                    del fs[prev]

            # now extend the window
            while rightPtr < flen and (types < 2 or (types == 2 and fruits[rightPtr] in fs)):
                num = fruits[rightPtr]
                if num not in fs:
                    fs[num] = 1
                    types += 1
                else:
                    fs[num] += 1
                rightPtr += 1
                result = max(result, (rightPtr - i))

            if rightPtr == flen: 
                break

        return result

### test ###
s = Solution()

fruits = [1,2,1]
print(s.totalFruit(fruits), 3)

fruits = [0,1,2,2]
print(s.totalFruit(fruits), 3)

fruits = [1,2,3,2,2]
print(s.totalFruit(fruits), 4)

# case 1: empty array
fruits = []
print(s.totalFruit(fruits), 0)

# case 2: single element
fruits = [1]
print(s.totalFruit(fruits), 1)

# case 3: only two element
fruits = [1,2,1,2,1,2,1,2]
print(s.totalFruit(fruits), len(fruits))
                
# case 4: max at the end
fruits = [1,2,3,4,2,1,2,1,2]
print(s.totalFruit(fruits), 5)
                
# case 5: max at the begining
fruits = [1,2,1,4,3,1,2,3,4]
print(s.totalFruit(fruits), 3)

# case 6: max in the middle
fruits = [1,2,1,4,3,3,3,4,1,2,3,4]
print(s.totalFruit(fruits), 5)
 
# case 7: random long case
import random
import time
start = time.time()
fruits = [random.randint(0, 10 ** 5) for _ in range(10 ** 5)]
end = time.time()
print(s.totalFruit(fruits), f" takes {end-start} seconds")

# case 8: all different elements
fruits = [1,2,3,4,5,6,7,8,1]
print(s.totalFruit(fruits), 2)
 
# wrong case 1:
fruits = [3,3,3,1,2,1,1,2,3,3,4]
print(s.totalFruit(fruits), 5)



