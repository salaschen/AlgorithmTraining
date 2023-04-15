# Bill Chen's solution
# leetcode: AC. time: 75.6%, mem: 12.53%.
class Solution:
    def search(self, nums: [int], target: int) -> int:
        nlen = len(nums)
        if nlen == 0:
            return -1

        low = 0
        high = nlen-1

        while high > low+1:
            mid = (high+low)//2
            if nums[mid] == target:
                return mid
            elif nums[mid] < target:
                low = mid
            else:
                high = mid
        
        if nums[low] == target:
            return low

        if nums[high] == target:
            return high
        
        return -1

### testing ###
s = Solution()
nums = [-1,0,3,5,9,12]
target = 9
print(s.search(nums, target))

target = 2
print(s.search(nums, target))

# case 1: out of range (too small)
nums = [-1,0,3,5,9,12]
target = -2
print(s.search(nums, target), -1)

# case 2: out of range (too large)
nums = [-1,0,3,5,9,12]
target = 13
print(s.search(nums, target), -1)

# case 3: left most element
nums = [-1,0,3,5,9,12]
target = -1 
print(s.search(nums, target), 0)

# case 4: right most element
nums = [-1,0,3,5,9,12]
target = 12
print(s.search(nums, target), len(nums)-1)

# case 5: middle hit
nums = [-1,0,3,5,9,12]
target = 3 
print(s.search(nums, target), 2)

# case 6: middle hit 2
nums = [-1,0,3,5,9,12]
target = 5 
print(s.search(nums, target), 3)

# case 7: middle miss
nums = [-1,0,3,5,9,12]
target = 4 
print(s.search(nums, target), -1)

# case 8: empty array
nums = []
target = 4 
print(s.search(nums, target), -1)

# case 9: one element array (hit)
nums = [1]
target = 1 
print(s.search(nums, target), 0)

# case 10: one element array (miss)
nums = [1]
target = 2 
print(s.search(nums, target), -1)
