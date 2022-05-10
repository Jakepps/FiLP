write_list([]) :- !.
write_list([X|T]) :- write(X), nl, write_list(T).

if(X,F1,_) :- X,F1.
if(_,_,F2) :- F2.

%1(38)
countAB([],A,B,Count):-Count is 0,!.
countAB([H|T],A,B,Count):-
    (
        B >= H,
        H >= A,
        countAB(T,A,B,Count1),
        Count is Count1+1;
        countAB(T,A,B,Count)
    ).
task1 :- L=[1,2,3,4,5,6,7,8,9,10],countAB(L,4,8,X),write(X),!.
%2(44)
isInt(A):-
    IntA is round(A),
    IntA = A.

alt([H|T],F):-
    isInt(H),

    alt(T,F,1);

    alt(T,F,0).
alt([],F,NewF):-F is 1,!.
alt([H|T],F,NewF):-
    (
        isInt(H),
        NewF is 0,

        alt(T,F,1)
    );
    (
        not(isInt(H)),
        NewF is 1,

        alt(T,F,0)
    );
    (
        F is 0
    ).
task2 :- L=[1,2.0,3,4.0,5],alt(L,F),write(F),!.
%3(56)
isDivisible(Number, Divisor):-
  Number mod Divisor = 0, !.
isDivisible(Number, Divisor):-
  Divisor * Divisor =< Number,
  NextDivisor = Divisor + 1,
  isDivisible(Number, NextDivisor).
isPrime(1):-!.
isPrime(Number):-
  Number > 0,
  not(isDivisible(Number, 2)).

sumP([],0,0):-!.
sumP([H|T],N,S):-
    sumP(T,N1,S1),
    N is N1+1,
    if(isPrime(H),
         S is S1+H,
          S is S1).
avgP(L,A):-
    sumP(L,N,S),
    A is S/N.

sumN([],0,0):-!.
sumN([H|T],N,S):-
    sumN(T,N1,S1),
    N is N1+1,
    if(not(isPrime(H)),
         S is S1+H,
          S is S1).
avgN(L,A):-
    sumN(L,N,S),
    A is S/N.

task3:-L=[1,2,3,4,5],avgN(L,X),avgP(L,A),if(X>A,write(X),write('No')),!.
