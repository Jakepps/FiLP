man(voeneg).
man(ratibor).
man(boguslav).
man(velerad).
man(duhovlad).
man(svyatoslav).
man(dobrozhir).
man(bogomil).
man(zlatomir).

woman(goluba).
woman(lubomila).
woman(bratislava).
woman(veslava).
woman(zhdana).
woman(bozhedara).
woman(broneslava).
woman(veselina).
woman(zdislava).

parent(voeneg,ratibor).
parent(voeneg,bratislava).
parent(voeneg,velerad).
parent(voeneg,zhdana).

parent(goluba,ratibor).
parent(goluba,bratislava).
parent(goluba,velerad).
parent(goluba,zhdana).

parent(ratibor,svyatoslav).
parent(ratibor,dobrozhir).
%
parent(zdislava,dobrozhir).
parent(dobrozhir,boguslav).
%
parent(lubomila,svyatoslav).
parent(lubomila,dobrozhir).

parent(boguslav,bogomil).
parent(boguslav,bozhedara).
parent(bratislava,bogomil).
parent(bratislava,bozhedara).

parent(velerad,broneslava).
parent(velerad,veselina).
parent(veslava,broneslava).
parent(veslava,veselina).

parent(duhovlad,zdislava).
parent(duhovlad,zlatomir).
parent(zhdana,zdislava).
parent(zhdana,zlatomir).

parent(svyatoslav,rustam).

%if
if(X,F1,_) :- X,F1.
if(_,_,F2) :- F2.

%11
son(X,Y):- parent(Y,X),man(X).
son(X) :- parent(X,Y),man(Y),print(Y),nl,fail.
%12
sister(X,Y):- parent(X,Z),parent(Y,Z),woman(X),man(Y).
sister(X):- sister(Y,X),print(Y),nl,fail.
%13
grand_so(X,Y):- parent(X,Z),parent(Z,Y),man(X).
grand_sons(X):- grand_so(Y,X),print(Y),nl,fail.
%14
grand_pa(X,Y) :- parent(Y,Z),parent(Z,X),man(X).
grand_pa_and_da(X,Y) :- woman(Y),man(X),(grand_pa(X,Y);grand_pa(Y,X)).
%15
findMaxNumberUp(X,Y) :- X < 10, Y is X.
findMaxNumberUp(X,Y) :-
    N is X mod 10,
    V is X // 10,
    findMaxNumberUp(V,C),
    Y is max(N,C).
%16
findMaxNumberDown(X,Y,Z) :- X < 10, Y is max(X,Z).
findMaxNumberDown(X,Y,Z) :-
    N is X mod 10,
    V is X // 10,
    NewZ is max(Z,N),
    findMaxNumberDown(V,Y,NewZ).
findMaxNumberDown(X,Y) :- findMaxNumberDown(X,Y,0).

%17
findSumNumsUp(X,Y) :-
    X < 10,
    Mod is X mod 3,
    if(0 is Mod, Y is 1, Y is X).
findSumNumsUp(X,Y) :-
    V is X div 10,
    N is X mod 10,
    Mod is N mod 3,
    if(1 is Mod,
        findSumNumsUp(V,Y),
        (findSumNumsUp(V,C), Y is N + C)).
%18
findSumNumsDown(X,Y,Z) :-
    X < 10,
    Mod is X mod 3,
    if(1 is Mod,
        Y is Z,
        Y is Z + X).
findSumNumsDown(X,Y,Z) :-
    N is X mod 10,
    V is X div 10,
    Mod is N mod 3,
    if(1 is Mod,
        NewZ is Z,
        NewZ is N + Z),
    findSumNumsDown(V,Y,NewZ).
findSumNumsDown(X,Y) :- findSumNumsDown(X,Y,0).
%19
fibUp(N,X) :- N < 3, X is 1.
fibUp(N,X) :- N1 is N - 1, N2 is N - 2, fibUp(N1,X1), fibUp(N2,X2), X is X1 + X2.
fibwru(N,X):- fibUp(N,X),print(X),nl.

%20
fibDown(0,X,LX,PLX) :- X is LX + PLX.
fibDown(N,X,_,_) :- N < 0, X is 1.
fibDown(N,X,LX,PLX) :-
    NewN is N - 1,
    NLX is LX + PLX,
    NPLX is LX,
    fibDown(NewN, X, NLX,NPLX).
fibDown(N,X) :- N1 is N - 2, fibDown(N1,X,1,0).
fibwrd(N,X):- fibDown(N,X),print(X),nl.
