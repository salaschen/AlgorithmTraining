# 977 Squares of a Sorted Array (Easy)
# Date: 25/Apr/2023
# Author: Ruowei Chen
# Note: Using two pointers

class Solution:
    # time: 221 ms, 66.6%
    # mem:  16.2 MB, 76%
    def sortedSquares(self, nums: [int]) -> [int]:
        nlen = len(nums)
        result = [0 for _ in range(nlen)]

        left, right = 0, nlen-1
        index = nlen-1
        lnum = nums[left] * nums[left]
        rnum = nums[right] * nums[right]

        while index >= 0:
            if lnum  > rnum: 
                result[index] = lnum 
                left += 1
                lnum = nums[left] * nums[left]
            else:
                result[index] = rnum
                right -= 1
                rnum = nums[right] * nums[right]
            index -= 1

        return result


### test ###
s = Solution()
nums = [-4, -1, 0, 3, 10]
print(s.sortedSquares(nums))

nums = [-7, -3, 2, 3, 11]
print(s.sortedSquares(nums))

nums = [-5, -3, -2, -1]
print(s.sortedSquares(nums))

