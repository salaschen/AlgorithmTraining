# 76 Minimum Window Substring - Hard
# Author: Ruowei Chen
# Date: 29/Apr/2023
# Note: sliding window.

class Solution:
    # time: 6.3%
    # mem: 5%
    def minWindow(self, s: str, t: str) -> str:
        tdict = dict()
        sdict = dict()
        for ch in t:
            if ch in tdict:
                tdict[ch] += 1
            else:
                tdict[ch] = 1
                sdict[ch] = 0
        right = 1
        slen = len(s)
        result = ""

        if slen == 0 or len(t) == 0:
            return ""

        if s[0] in sdict:
            sdict[s[0]] = 1
        if self.compatible(sdict, tdict):
            result = s[0]


        for i in range(1, slen):
            # remove the previous character
            prev = s[i-1]
            if prev in sdict:
                sdict[prev] -= 1

            if s[i] not in sdict:
                continue

            # extend the window if needed
            while not self.compatible(sdict, tdict) and right < slen:
                rch = s[right]
                if rch in sdict:
                    sdict[rch] += 1
                right += 1

            # test if it's compatible
            if self.compatible(sdict, tdict):
                curStr = s[i:right]
                # print(s) # debug
                # print(i, right, curStr, sdict) # debug
                result = curStr if (result == "" or len(result) > len(curStr)) else result
        return result

    def compatible(self, sdict: dict, tdict: dict) -> bool:
        for ch in tdict:
            if sdict[ch] < tdict[ch]:
                return False
        return True


### test ###
sol = Solution()
ch = list('abcdefghijklmnopqrstuvwxyz')
ch = ch + list(map(lambda n: n.upper(), ch))
print(ch)

s = "ADOBECODEBANC"
t = "ABC"
print("actual: ", sol.minWindow(s, t), "\texpect: BANC")

s = "a"
t = "a"
print("actual: ", sol.minWindow(s, t), "\texpect: a")

s = "a"
t = "aa"
print(f"actual: \"{sol.minWindow(s, t)}\"\texpect: \"\"")

# case 8: large random case
import random
import time
sizeS = 10 ** 5
sizeT = 10 ** 4
t = [random.choice(ch) for _ in range(sizeT)]
s = [random.choice(ch) for _ in range(sizeS)]
start = time.time()
result = (sol.minWindow(s, t))
end = time.time()
print(f'large case: {end-start} seconds');

# case 7: in reverse order
s = "abcccba"
t = "cba"
print(f"actual: \"{sol.minWindow(s, t)}\"\texpect: \"abc\"")

# case 6: matching with lower and upper
s = "aAAAaBcCcbcaAcbc"
t = "aAbcc"
print(f"actual: \"{sol.minWindow(s, t)}\"\texpect: \"None\"")

# case 5: matching at the end
s = "aaaaaabecd"
t = "aabc"
print(f"actual: \"{sol.minWindow(s, t)}\"\texpect: \"aabec\"")


# case 1:  empty
s = ""
t = "abc"
print(f"actual: \"{sol.minWindow(s, t)}\"\texpect: \"\"")

# case 2: empty s and t
s = ""
t = ""
print(f"actual: \"{sol.minWindow(s, t)}\"\texpect: \"\"")

# case 3: capital s and lower t
s = "ABC"
t = "abc"
print(f"actual: \"{sol.minWindow(s, t)}\"\texpect: \"\"")

# case 4: lower s and capital t
s = "abc"
t = "ABC"
print(f"actual: \"{sol.minWindow(s, t)}\"\texpect: \"\"")




