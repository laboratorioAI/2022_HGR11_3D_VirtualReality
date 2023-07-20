function [proccesingTime, gestoResultKNN] = classifierEMG(emg, datasetGestures, kNNemg,probabilidadkNNUmbral)

nameStaticGestures={'relax';'waveIn';'waveOut';'fist';'open';'pinch'};
numGestures=6;
numTry=15;

ordenFiltro=4;
freqFiltro=0.05;
[Fb, Fa] = butter(ordenFiltro, freqFiltro, 'low'); % creating filter

%% Initializing variables
[sizeDatasetGestures,~]=size(datasetGestures);

DTWUnknownGesture=zeros(numTry*numGestures,8);

%% ############# INPUT SIGNAL #############################################################
tClassification=tic;
emg = filtfilt(Fb, Fa,abs(emg));
%% ##############           DTW-EMG         ######################################################################################

parfor kDatasetGesures=1:sizeDatasetGestures
    for kChannel=1:8
        DTWUnknownGesture(kDatasetGesures,kChannel)=...
            dtw_c(datasetGestures{kDatasetGesures,kChannel}, emg(:, kChannel), 50);
    end
end

%% ##############           KNN-EMG         #######################################################################################
DTWsumChannelEMG=sum(DTWUnknownGesture,2);

[~,kNNresults]=sort(DTWsumChannelEMG);

kNNresults=ceil(kNNresults/numTry);

% Choosing the closest k
kNNresults=kNNresults(1:kNNemg,:);

% % Finding the most common among the nearest neighbors
[gestoResultKNN,probGestureKNN]=mode(kNNresults);
%gestoResultKNN = me devuelve el valor que mas se repite
%probGestureKNN = me devuelve el numero de veces que gesTesultKNN se repite

% chance per unit
probGestureKNN=probGestureKNN/kNNemg;
% numero de reps del gestoResult / KNN

% Naming the resulting gesture
gestoString=char(nameStaticGestures{gestoResultKNN});


%% Umbral
if probGestureKNN>=probabilidadkNNUmbral
    fprintf('%s,          %4.2f %%...\n', gestoString , probGestureKNN*100);

else
    fprintf('relax %4.2f %%...\n',probGestureKNN);
    gestoResultKNN=1;
end
proccesingTime = toc(tClassification);
% fprintf('\n');
end