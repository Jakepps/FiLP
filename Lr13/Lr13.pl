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
length([], 0):- !.       % ���� ������ ������, ��� ����� ����� ����
length([_|T], L) :-  % ����� �������� ������� ������, ��������� ������,
    length(T, L_T),  % ���������� ��������� ����� ����� ������� ������
    L = L_T + 1.     % � ���������� �������, ������� ����� ��������� ������

avg(L,A):-           % L - ������, A - ������� (average)
    sum(L,S),        % ������� ������� ����� (S)
    length(L,K),     % ����� ���������� ��������� (K)
    A=S/K.           % � ��������� �������
