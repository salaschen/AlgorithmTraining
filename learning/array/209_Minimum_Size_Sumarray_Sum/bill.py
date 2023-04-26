# 209: Minimum Size Subarray Sum
# Date: 26/Apr/2023
# Author: Ruowei Chen
# Note: Sliding window
class Solution:
    # time: 41.5%
    # mem: 82.8%
    def minSubArrayLen(self, target: int, nums: [int]) -> int:
        if target <= 0:
            return 0
        nlen = len(nums)
        if nlen == 0:
            return 0
        result = nlen+1

        Sum = 0
        left = 0

        for right in range(nlen):
            Sum += nums[right]

            while Sum >= target:
                result = result if result < (right-left+1) else  (right-left+1)
                Sum -= nums[left]
                left += 1

            
        return 0 if result > nlen else result

    # two pointer solution to move the window
    # time: 23.7%
    # mem: 7.5%
    def minSubArrayLenOld(self, target: int, nums: [int]) -> int:
        if target <= 0:
            return 0

        lowPtr, upPtr = 0, 0
        nlen = len(nums)
        if nlen == 0:
            return 0
        result = 0
        cur = nums[0]
        hasImproved = True 
        
        while upPtr <= nlen-1 and hasImproved:
            hasImproved = False
            while cur < target and upPtr < nlen-1:
                upPtr += 1
                cur += nums[upPtr]
                hasImproved = True

            # now it's either 1) cur >= target or 2) upPtr == nlen
            if cur >= target:
                result =  (upPtr-lowPtr+1) if (result == 0) else min(result, (upPtr-lowPtr+1))
                # now shrinks the window
                cur -= nums[lowPtr]
                lowPtr += 1
                while lowPtr <= upPtr and cur >= target:
                    result = min(result, (upPtr-lowPtr+1))
                    cur -= nums[lowPtr]
                    lowPtr += 1

                if upPtr < lowPtr:
                    upPtr = lowPtr
                    if lowPtr < nlen:
                        cur = nums[lowPtr]
                # now the window is shrinked to just below the target, ready for the next loop
            else:
                # upPtr == nlen
                # do nothing, the loop will exit
                pass 
        return result

### test ###
s = Solution()
target = 7
nums = [2,3,1,2,4,3]
print(s.minSubArrayLen(target, nums), 2)

target = 4
nums = [1,4,4]
print(s.minSubArrayLen(target, nums), 1)

target = 11
nums = [1,1,1,1,1,1,1,1]
print(s.minSubArrayLen(target, nums), 0)

# case 1: empty array
target = 1
nums = []
print(s.minSubArrayLen(target, nums), 0)

# case 2: single element array (failed)
target = 2
nums = [1]
print(s.minSubArrayLen(target, nums), 0)

# case 3: single element array (success)
target = 2
nums = [2]
print(s.minSubArrayLen(target, nums), 1)

# case 4: full array just satisfy
target = 6
nums = [1,2,3]
print(s.minSubArrayLen(target, nums), 3)

# case 5: single number can satisfy
target = 6
nums = [1,7,3,4,5]
print(s.minSubArrayLen(target, nums), 1)

# case 6: subarray at the end
target = 6
nums = [1,1,2,3,4,5,6]
print(s.minSubArrayLen(target, nums), 1)

# case 7: subarray in the middle
target = 11
nums = [1,2,3,4,8,2,9,1]
print(s.minSubArrayLen(target, nums), 2)


