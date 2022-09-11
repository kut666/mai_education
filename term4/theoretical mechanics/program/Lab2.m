function varargout = Lab2(varargin)
% LAB2 MATLAB code for Lab2.fig
%      LAB2, by itself, creates a new LAB2 or raises the existing
%      singleton*.
%
%      H = LAB2 returns the handle to a new LAB2 or the handle to
%      the existing singleton*.
%
%      LAB2('CALLBACK',hObject,eventData,handles,...) calls the local
%      function named CALLBACK in LAB2.M with the given input arguments.
%
%      LAB2('Property','Value',...) creates a new LAB2 or raises the
%      existing singleton*.  Starting from the left, property value pairs are
%      applied to the GUI before Lab2_OpeningFcn gets called.  An
%      unrecognized property name or invalid value makes property application
%      stop.  All inputs are passed to Lab2_OpeningFcn via varargin.
%
%      *See GUI Options on GUIDE's Tools menu.  Choose "GUI allows only one
%      instance to run (singleton)".
%
% See also: GUIDE, GUIDATA, GUIHANDLES

% Edit the above text to modify the response to help Lab2

% Last Modified by GUIDE v2.5 31-May-2020 13:14:54

% Begin initialization code - DO NOT EDIT
gui_Singleton = 1;
gui_State = struct('gui_Name',       mfilename, ...
                   'gui_Singleton',  gui_Singleton, ...
                   'gui_OpeningFcn', @Lab2_OpeningFcn, ...
                   'gui_OutputFcn',  @Lab2_OutputFcn, ...
                   'gui_LayoutFcn',  [] , ...
                   'gui_Callback',   []);
if nargin && ischar(varargin{1})
    gui_State.gui_Callback = str2func(varargin{1});
end

if nargout
    [varargout{1:nargout}] = gui_mainfcn(gui_State, varargin{:});
else
    gui_mainfcn(gui_State, varargin{:});
end
% End initialization code - DO NOT EDIT


% --- Executes just before Lab2 is made visible.
function Lab2_OpeningFcn(hObject, eventdata, handles, varargin)
% This function has no output args, see OutputFcn.
% hObject    handle to figure
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
% varargin   command line arguments to Lab2 (see VARARGIN)

% Choose default command line output for Lab2
handles.output = hObject;

% Update handles structure
guidata(hObject, handles);

% UIWAIT makes Lab2 wait for user response (see UIRESUME)
% uiwait(handles.figure1);


% --- Outputs from this function are returned to the command line.
function varargout = Lab2_OutputFcn(hObject, eventdata, handles) 
% varargout  cell array for returning output args (see VARARGOUT);
% hObject    handle to figure
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)

% Get default command line output from handles structure
varargout{1} = handles.output;


% --- Executes on button press in pushbutton1.
function pushbutton1_Callback(hObject, ~, handles)
% hObject    handle to pushbutton1 (see GCBO)
% eventdata  reserved - to be defined in a future version of MATLAB
% handles    structure with handles and user data (see GUIDATA)
cla
syms t

global m l0 l1 l2 c g % Параметры системы бъявим глобальными переменными 
g = 9.8; % Ускорение свободного падения 
m = 0.1; % Масса точки М1 и М2 
l0 = 1; % Длина пружины 
l1 = 0.5; % Длина стержня 1 
l2 = 0.5; % Длина стержня 2 
c = 5; % Жёсткость пружины 

y0 = [3.14/10, 3.14/10, 0, 0];%Начальные условия фи, кси, дфи, дкси 
t0 = 0; %Начальное время интегрирования (сек) 
grstep = 0.01; %Шаг выдачи результатов интегрирования (сек) 
tfin = 20; %Конечное время интегрирования 
tout=[t0:grstep:tfin]; % создадим массив моментов времени  
[t,y]=ode45(@sys,tout,y0); 

phi=y(:,1); % для удобства введём величины фи и кси 
psi=y(:,2); 

figure;
axis equal
xlim([-2 2])
ylim([-2 2])
xlim manual
ylim manual
hold on

plot([0 20],[0 0]); 
plot([0 0],[0 -20]);

O = plot(0,0,'blacko','markerfacecolor','black');      
A = plot(l1*sin(phi(1)),-1*l1*cos(phi(1)),'go','markerfacecolor','green');
B = plot(l1*sin(phi(1)) + l2*sin(psi(1)), -1*l1*cos(phi(1)) - 1*l2*cos(psi(1)),'bo','markerfacecolor','blue');
D = plot(-l0, -1*l1*cos(phi(1)),'go');
OA = plot([0 l1*sin(phi(1))],[0 -1*l1*cos(phi(1))],'yellow');  
DA = plot([-l0 l1*sin(phi(1))],[-1*l1*cos(phi(1)) -1*l1*cos(phi(1))],'green');
AB = plot([l1*sin(phi(1)) l1*sin(phi(1)) + l2*sin(psi(1))],[-1*l1*cos(phi(1)) -1*l1*cos(phi(1)) - 1*l2*cos(psi(1))],'black'); 

figure;
plot(t,y); 
legend('Фи', 'Кси', 'Фи*', 'Кси*'); 
title('Решения диф. уравнения'); 
grid on; 
xlabel('t'); 
ylabel('y');

for i=1:length(t)
    res = sys(t(i),y(1,:));
    phit = res(1);
    psit = res(2);
    phitt = res(3);
    psitt = res(4);
end

N = m.*(g.*cos(psi)- l1.*(phitt.*sin(psi-phi)- phit.*phit.*cos(psi-phi)) + l2.*psit.*psit);

figure;
plot(t,N);
title('Реация N'); 
grid on; 
xlabel('t'); 
ylabel('N');

 for i=1:length(t) 
     set(A,'XData',l1*sin(phi(i)),'YData',-1*l1*cos(phi(i)));
     set(B,'XData',l1*sin(phi(i)) + l2*sin(psi(i)),'YData',-1*l1*cos(phi(i)) - 1*l2*cos(psi(i)));
     set(D,'YData',-1*l1*cos(phi(i)),'markerfacecolor',[0.91076*(sin(t(i)))^2 0.1364 0.756543*(cos(t(i)))^2]); 
     set(OA,'XData',[0 l1*sin(phi(i))],'YData',[0 -1*l1*cos(phi(i))]); 
     set(DA,'XData',[-l0 l1*sin(phi(i))],'YData',[-1*l1*cos(phi(i)) -1*l1*cos(phi(i))]);
     set(AB,'XData',[l1*sin(phi(i)) l1*sin(phi(i)) + l2*sin(psi(i))],'YData',[-1*l1*cos(phi(i)) -1*l1*cos(phi(i)) - 1*l2*cos(psi(i))]);  
     pause(0.01);
 end
