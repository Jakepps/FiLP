read_list(0, []) :- !.
read_list(I, [X|T]) :- read(X), I1 is I - 1, read_list(I1, T).

write_list([]) :- !.
write_list([X|T]) :- write(X), nl, write_list(T).

delete([], _Elem, []):-!.
delete([Elem|Tail], Elem, ResultTail):-
   delete(Tail, Elem, ResultTail), !.
delete([Head|Tail], Elem, [Head|ResultTail]):-
   delete(Tail, Elem, ResultTail).

%11
nod(N,0,N):-!.
nod(N,M,R):-M1 is N mod M,N1 is M,nod(N1,M1,R).

countSimpleD(A,X):- cocsD(A,X,A,0).
csD(A,R,0,R):-!.
csD(A,X,I,R):- I1 is I-1,(nod(A,I1,D),D is 1,R1 is R+1,csD(A,X,I1,R1);csD(A,X,I1,R)),!.

countSimpleU(A,X):- cocsU(A,X,A).
csU(A,X,0):-X is 0,!.
csU(A,X,I):- I1 is I-1, csU(A,X1,I1),(nod(A,I1,D),D is 1,X is X1+1;X is X1),!.

%12
delNum(A,X):- dws(X,A,A,0,0).

dws(X,A,1,CMD,MD):-X is MD,!.
dws(X,A,I,CMD,MD):-
    I1 is I-1,
    (
        0 is (A mod I),
        codwc(COUNT_CROSS_SIMPLE,A,I),
        (
            COUNT_CROSS_SIMPLE >= CMD,
            dws(X,A,I1,COUNT_CROSS_SIMPLE,I);
            dws(X,A,I1,CMD,MD)
        );
        dws(X,A,I1,CMD,MD)
    ),
    !.

codwc(COUNT_CROSS_SIMPLE,0,DEL):- COUNT_CROSS_SIMPLE is 0,!.
codwc(COUNT_CROSS_SIMPLE,NUM,DEL):-
    NUM1 is NUM div 10,
    (
        nod(NUM mod 10,DEL,D),
        D is 1,
        codwc(COUNT_CROSS_SIMPLE1,NUM1,DEL),
        COUNT_CROSS_SIMPLE is COUNT_CROSS_SIMPLE1+1;
        codwc(COUNT_CROSS_SIMPLE,NUM1,DEL)
    ),
    !.
%13
fact(N, X, N, X) :- !.
fact(N, X, N1, X1) :- N2 is N1 + 1, X2 is N2 * X1, fact(N, X, N2, X2).
fact(N, X) :- fact(N, X, 0, 1).

sumcifr_f(N, Sum) :- sumcifr_f(N, Sum, 0).
sumcifr_f(0, Sum, Sum) :- !.
sumcifr_f(N, Sum, CurSum) :- D is N mod 10, fact(D, D1), NewSum is CurSum + D1, N1 is N div 10, sumcifr_f(N1, Sum, NewSum).

intr_number(X) :- sumcifr_f(X, SF), X = SF.

task13(2, Result, Result) :- !.
task13(CurN, CurSum, Result) :- NewN is CurN - 1, (intr_number(CurN), NewSum is CurSum + CurN; NewSum is CurSum), task13(NewN, NewSum, Result), !.
task13(Result) :- task13(200000, 0, Result).

%14
list_length([],0).
list_length([_|Tail],L) :- list_length(Tail,Count), L is Count + 1,!.
%15
% Склеить 2 списка (первые 2 перменных - два списка, третья - результат)
join([], X, X).
join([X|Y], Z, [X|W]) :- join(Y, Z, W).

% Циклический сдвиг списка влево на N
shift_left(Result, 0, Result) :- !.
shift_left([X|T], N, Result) :- N1 is N - 1, join(T, [X], NewList), shift_left(NewList, N1, Result), !.

% Циклический сдвиг списка влево на 2
shift_left_3([X|T], Result) :- shift_left([X|T], 2, Result).

task15 :- L=[1,2,3,4,5], shift_left_3(L, L2), write('Shifted list: '), nl, write_list(L2), !.

%16
% Получить элемент списка по индексу
get_elem_by_idx([X|_], 0, X) :- !.
get_elem_by_idx([_|T], Idx, Result) :- Idx1 is Idx - 1, get_elem_by_idx(T, Idx1, Result).
% Получить минимальный элемент списка
list_min([], Result, Result) :- !.
list_min([X|T], CurrentMin, Result) :- (X < CurrentMin, NewMin is X; NewMin is CurrentMin), list_min(T, NewMin, Result), !.
list_min([X|T], Result) :- list_min([X|T], X, Result).

task16 :- L=[1,2,-3,4,5],list_min(L, X),write(X),nl,delete(L,X,L2),list_min(L2,Y),write(Y), !.
%17
% Вернуть список, содержащий все элементы исходного до числа Z.
get_before([], _, Result, Result) :- !. % Частный случай, когда Z нет в списке
get_before([X|_], X, Result, Result) :- !.
get_before([X|T], Z, CurList, Result) :- join(CurList, [X], NewList), get_before(T, Z, NewList, Result), !.
get_before([X|T], Z, Result) :- get_before([X|T], Z, [], Result).

task17 :- L=[1,2,3,4,2,5,-2], list_min(L, Min), get_before(L, Min, L2), write("Result:"), nl, write_list(L2), !.

%18
% Получить максимальный элемент списка
list_max([], Result, Result) :- !.
list_max([X|T], CurrentMax, Result) :- (X > CurrentMax, NewMax is X; NewMax is CurrentMax), list_max(T, NewMax, Result), !.
list_max([X|T], Result) :- list_max([X|T], X, Result).

% Содержится ли элемент Y в списке
contains([Y|_], Y) :- !.
contains([], _) :- !, fail.
contains([_|T], Y) :- contains(T, Y), !.

% Получить все пропущенные элементы списка
build_missing(_, Min, Min, Result, Result) :- !.
build_missing(OrigList, Min, I, AccumList, Result) :- NewI is I - 1, (contains(OrigList, I), join([], AccumList, NewList); join([I], AccumList, NewList)), build_missing(OrigList, Min, NewI, NewList, Result), !.
build_missing(OrigList, Result) :- list_min(OrigList, Min), list_max(OrigList, Max), build_missing(OrigList, Min, Max, [], Result).

task18 :- L=[1,2,6,7,10], build_missing(L, L2), write('Missing: '), nl, write_list(L2), !.

%19
local_maximum([X,Y,Z], [Y|Ms]):-
  nonvar(X), nonvar(Y), nonvar(Z),
  Y>X, Y>Z, !.

local_maximum([X,Y,Z|Xs], [Y|Ms]):-
  nonvar(X), nonvar(Y), nonvar(Z),
  Y>X, Y>Z,
  local_maximum([X,Z|Xs], Ms).

local_maximum([X,Y,Z|Xs], Ms):-
  nonvar(X), nonvar(Y), nonvar(Z),
  local_maximum([X,Z|Xs], Ms), !.
task19:- L=[1,2,3,4,2,3,1,5,3], local_maximum(L,An),write(An),nl,list_length(An,X),write(X),!.
%20
task20:- L=[1,2,3,44,5,6],list_max(L,X),(0 is X mod 2, write(X);write('Cringe')),!.
