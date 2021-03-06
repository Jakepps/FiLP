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
    (F is 0).
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
    if(isPrime(H),
         S is S1,
          S is S1+H).
avgN(L,A):-
    sumN(L,N,S),
    A is S/N.

task3:-L=[1,2,3,4,5,7],avgN(L,X),avgP(L,A),if(X>A,write(X),write('No')),!.

%4
inList([],_):-fail.
inList([X|_],X).
inList([_|T],X):-inList(T,X).

task4:-
    Hairs=[_,_,_],
    inList(Hairs,[belov,_]),
    inList(Hairs,[chernov,_]),
    inList(Hairs,[rijov,_]),
    inList(Hairs,[_,redhead]),
    inList(Hairs,[_,blond]),
    inList(Hairs,[_,brunet]),
    not(inList(Hairs,[belov,blond])),
    not(inList(Hairs,[chernov,brunet])),
    not(inList(Hairs,[rijov,redhead])),
    write(Hairs),
    !.
%5
task5 :- task5([_,_,_]).
task5(List) :-

    inList(List,[anya,X,X]),
    inList(List,[valya,_,_]),
    inList(List,[natasha,_,green]),

    inList(List,[_,white,_]),
    inList(List,[_,green,_]),
    inList(List,[_,blue,_]),

    inList(List,[_,_,white]),
    inList(List,[_,_,green]),
    inList(List,[_,_,blue]),

    not(inList(List,[valya,Y,Y])),
    not(inList(List,[natasha,Z,Z])),

    not(inList(List,[valya,_,white])),
    not(inList(List,[valya,white,_])),

    write(List),!.
%6
task6:-
    List=[_,_,_],
    inList(List,[slesar,_,0,0,_]),
    inList(List,[tokar,_,_,1,_]),
    inList(List,[svarshick,_,_,_,_]),
    inList(List,[_,semenov,_,2,borisov]),
    inList(List,[_,ivanov,_,_,_]),
    inList(List,[_,borisov,1,_,_]),
    write(List),
    !.
%7
right(_,_,[_]):-fail.
right(A,B,[A|[B|_]]).
right(A,B,[_|List]):-right(A,B,List).

left(_,_,[_]):-fail.
left(A,B,[B|[A|_]]).
left(A,B,[_|List]):-left(A,B,List).

next(A,B,List):-right(A,B,List).
next(A,B,List):-left(A,B,List).

%7
task7:-
    List=[_,_,_,_],
    inList(List,[bottle,_]),
    inList(List,[glass,_]),
    inList(List,[kuvshin,_]),
    inList(List,[banka,_]),
    inList(List,[_,milk]),
    inList(List,[_,lemonade]),
    inList(List,[_,kvas]),
    inList(List,[_,vodka]),

    not(inList(List,[bottle,milk])),
    not(inList(List,[bottle,vodka])),
    not(inList(List,[banka,lemonade])),
    not(inList(List,[banka,vodka])),
    right([kuvshin,_],[_,lemonade],List),
    right([_,lemonade],[_,kvas],List),
    next([glass,_],[banka,_],List),
    next([glass,_],[_,milk],List),
    write(List),!.
%8
task8 :-
    List = [_,_,_,_],
    inList(List,[voronov,_]),
    inList(List,[pavlov,_]),
    inList(List,[levizkiy,_]),
    inList(List,[saharov,_]),
    inList(List,[_,dancer]),
    inList(List,[_,artist]),
    inList(List,[_,singer]),
    inList(List,[_,writer]),
    not(inList(List,[voronov,singer])),
    not(inList(List,[levizkiy,singer])),
    not(inList(List,[pavlov,writer])),
    not(inList(List,[pavlov,artist])),
    not(inList(List,[saharov,writer])),
    not(inList(List,[voronov,writer])),
    (
        inList(List,[voronov,artist]), % ??? ??? ??????? ?? ?????? ? ????????, ?? ?? ?? ??? ??? ????????, ???? ?? ???????? ??????????
        not(inList(List,[levizkiy,writer]));

        not(inList(List,[voronov,artist]))
    ),
    write(List),!.
%9
task9:-
    List = [_,_,_],
    inList(List,[maikl,_,basket,A]),
    inList(List,[saimon,israel,_,C]),
    inList(List,[_,_,cricket,1]),
    inList(List,[richard,_,_,_]),

    inList(List,[_,_,tenis,D]),
    inList(List,[_,american,_,B]),
    inList(List,[_,australian,_,_]),
    inList(List,[_,_,_,2]),
    inList(List,[_,_,_,3]),

    not(inList(List,[maikl,american,_,_])),
    not(inList(List,[saimon,_,tenis,_])),
    A<B,
    C<D,
    write(List),!.
%10
%[???,?????????,?????? ?????]
task10:-
    List = [_,_,_,_,_],
    inList(List,[_,_,lev]),
    inList(List,[_,_,harkov]),
    inList(List,[_,_,moscow]),
    inList(List,[_,lev,_]),
    inList(List,[sergay,riga,_]),
    inList(List,[boris,penza,riga]),
    inList(List,[leo,_,X]),
    inList(List,[grig,harikov,_]),
    inList(List,[victor,moscow,_]),
    inList(List,[_,X,penza]),
    not(inList(List,[_,W,W])),
    write(List),!.
