# 844 Backspace String Compare - Easy
# Date: 25/Apr/2023
# Author: Ruowei Chen
# Note: Use two pointers
# time: 54.11%, mem: 12.46%

class Solution:
    def backspaceCompare(self, s: str, t: str) -> bool:
        slen,tlen = len(s),len(t)
        sPtr,tPtr = slen-1,tlen-1
        while sPtr >= 0 or tPtr >= 0:
            # first move the tPtr to a place where t[tPtr] has a meaningful character
            numSharp = 0
            tChar = ''
            if tPtr >= 0 and t[tPtr] == '#':
                numSharp = 1
                tPtr -= 1

            while (numSharp > 0 or t[tPtr] == '#') and tPtr >= 0 :
                if t[tPtr] == '#':
                    numSharp += 1
                else:
                    numSharp -= 1
                tPtr -= 1

            if tPtr >= 0:
                tChar = t[tPtr]
                tPtr -= 1
            # second, move the sPtr to a place where s[sPtr] has a meaningful character
            numSharp = 0
            sChar = ''
            if sPtr >= 0 and s[sPtr] == '#':
                numSharp = 1
                sPtr -= 1

            while (numSharp > 0 or s[sPtr] == '#') and sPtr >= 0:
                if s[sPtr] == '#':
                    numSharp += 1
                else:
                    numSharp -= 1
                sPtr -= 1

            if sPtr >= 0:
                sChar = s[sPtr]
                sPtr -= 1

            print(f'{sPtr+1} {sChar} | {tPtr+1}{tChar}')
            if sChar != tChar:
                return False
        return True

### test ###
sol = Solution()

s = 'ab#t'
t = 'ad#t'
print(sol.backspaceCompare(s,t), True)

s = 'ab##'
t = 'c#d#'
print(sol.backspaceCompare(s,t), True)

s = 'a#c'
t = 'b'
print(sol.backspaceCompare(s,t), False)

s = 'xywrrmp'
t = 'xywrrmu#p'
print(sol.backspaceCompare(s,t), True)

s = 'bbbextm'
t = 'bbb#extm'
print(sol.backspaceCompare(s,t), False)

