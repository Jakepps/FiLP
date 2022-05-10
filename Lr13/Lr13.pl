write_list([]) :- !.
write_list([X|T]) :- write(X), nl, write_list(T).
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
%3()
length([], 0):- !.       % если список пустой, его длина равна нулю
length([_|T], L) :-  % иначе выделяем остаток списка, игнорируя начало,
    length(T, L_T),  % рекурсивно вычисляем длину этого остатка списка
    L = L_T + 1.     % и прибавляем единицу, получая длину исходного списка

avg(L,A):-           % L - список, A - среднее (average)
    sum(L,S),        % сначала считаем сумму (S)
    length(L,K),     % потом количество элементов (K)
    A=S/K.           % и вычисляем среднее
