# 367: Valid Perfect Square - Easy
# Note: Use binary search
# Date: 25/Apr/2023

class Solution:
    def isPerfectSquare(self, num: int) -> bool:
        if num < 0:
            return False
        if num <= 1: 
            return True

        low = 2
        up = (2 ** 31)
        while up > low+1:
            mid = (low+up)//2
            product = mid ** 2
            if product == num:
                return True
            elif product > num:
                up = mid
            else:
                low = mid

        if low ** 2 == num:
            return True

        if up ** 2 == num:
            return True

        return False

### test code ###
def quick(num: int) -> bool:
    import math
    s = (int)(math.sqrt(num))
    return s ** 2 == num

def test():
    import random
    sol = Solution()
    size = 10000
    failed = 0
    for i in range(size):
        num = random.randint(0, 2 ** 31 - 1)
        expect = quick(num)
        actual = sol.isPerfectSquare(num)
        if expect != actual:
            failed += 1
            print(f'{num} failed');

    print(f'result: {size-failed}/{size} tests passed');
    return

test()



